using System;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using PVS.MediaPlayer;
using System.Data.SQLite;
using System.Drawing;

namespace XeviousPlayer2
{    
    public partial class AdicionaMusicas : Form
    {

        private ArrayList sFileList = new ArrayList();
        private int Quant = 0;
        private int Lidos = 0;
        private OperacoesBD Opbd;
        private int passo=0;

        public AdicionaMusicas()
        {
            InitializeComponent();
            ColocaSkin();
        }

        private void ColocaSkin()
        {
            string SQL = "Select Skin From Config";
            string ret = DalHelper.Consulta(SQL);
            int Skin = int.Parse(ret);
            using (var cmd = new SQLiteCommand(DalHelper.DbConnection()))
            {
                cmd.CommandText = "Select * From Skin Where ID = " + Skin;
                using (SQLiteDataReader regSkin = cmd.ExecuteReader())
                {
                    regSkin.Read();
                    int thiBacA = int.Parse(regSkin["labForA"].ToString());
                    int thiBacB = int.Parse(regSkin["labForB"].ToString());
                    int thiBacC = int.Parse(regSkin["labForC"].ToString());
                    int lvA = int.Parse(regSkin["thiBacA"].ToString());
                    int lvB = int.Parse(regSkin["thiBacB"].ToString());
                    int lvC = int.Parse(regSkin["thiBacC"].ToString());
                    this.BackColor = Color.FromArgb(thiBacA, thiBacB, thiBacC);
                    label1.BackColor = Color.FromArgb(lvA, lvB, lvC);
                }
            }
        }

        private void BuscaMusicas(string sPath)
        {
            {
                DirectoryInfo dirInfo = new DirectoryInfo(sPath);
                foreach (FileInfo Arq in dirInfo.GetFiles())
                {
                    //if (Lidos == 13)
                    //{
                    //    int x = 0;
                    //}
                    if (Gen.OPENMEDIA_DIALOG_FILTER.Contains(Arq.Extension))
                    {
                        if (Arq.Length>0) 
                            leMusica(Arq);
                    }
                    Lidos++;
                    //if (Lidos>1000)
                    //{
                    //    int x = 0;
                    //}
                    progressBar1.Value = Lidos;
                }
                //sFileList.AddRange(dirInfo.GetFiles());
                //foreach (DirectoryInfo subDirs in dirInfo.GetDirectories())
                //{
                //    sFileList.Add(subDirs.FullName);
                //    BuscaMusicas(subDirs.FullName);
                //}
            }
        }

        private void leMusica(FileInfo arq)
        {
            Player myPlayer = new Player();
            myPlayer.Mute = true;
            myPlayer.Play(arq.FullName);
            Metadata data = myPlayer.Media.GetMetadata();
            myPlayer.Stop();
            myPlayer.Dispose();
            Opbd.AdicionaNoBD(data, arq.Length, arq.FullName);
        }

        private void VeTotal(string sPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(sPath);
            foreach (FileInfo Arq in dirInfo.GetFiles())
            {
                if (Gen.OPENMEDIA_DIALOG_FILTER.Contains(Arq.Extension))
                    Quant++;
            }
            //sFileList.AddRange(dirInfo.GetFiles());
            //foreach (DirectoryInfo subDirs in dirInfo.GetDirectories())
            //{
            //    sFileList.Add(subDirs.FullName);
            //    VeTotal(subDirs.FullName);
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (passo)
            {
                case 0:
                    Processa();
                    break;
                case 1:
                    label1.Text = "Contanto Arquivos " + Quant.ToString();
                    break;
                case 2:
                    label1.Text = "Lendo Arquivos " + Quant.ToString();
                    break;
            }
        }

        private void Processa()
        {
            passo++;
            Opbd = new OperacoesBD();
            label1.Text = "Contanto Arquivos ";
            VeTotal(Gen.PastaMp3);
            label1.Text = "Quantidade localizada : " + Quant.ToString();
            progressBar1.Maximum = Quant;

            // Apaga a tabela de musicas a fim de testes
            // Na versão final deve ter uma opção para zerar a base de dados caso o usuário queira
            // mas a importação deve ser sempre incremental
            DalHelper.ExecSql("Delete from Musicas");
            DalHelper.ExecSql("Delete from Bandas");

            BuscaMusicas(Gen.PastaMp3);
            this.Close();
        }

        private void AdicionaMusicas_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
