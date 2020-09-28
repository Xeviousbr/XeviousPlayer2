using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Drawing;

namespace XeviousPlayer2
{
    public partial class Config : Form
    {
        private bool vazio = true;

        public Config()
        {
            InitializeComponent();
            String ret = DalHelper.Consulta("Select PathBase From Config"); 
            if (ret!=null)
            {
                textBox1.Text = ret;
                vazio = false;
            }
            ColocaSkin();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (vazio)
            //{
            //DalHelper.ExecSql("CREATE TABLE Config(PathBase Text) ");
            //DalHelper.ExecSql("Insert Into Config (PathBase) Values ('" + textBox1.Text + "')");
                Gen.PastaMp3 = textBox1.Text;
                AdicionaMusicas fAdi = new AdicionaMusicas();
            fAdi.ShowDialog();
            //} else
            //{
            //    DalHelper.ExecSql("Update Config Set PathBase = '" + textBox1.Text + "'");
            //}
            this.Close();
        }

        private void ColocaSkin()
        {
            // Por enquanto tem só duas telas que usam o Skin
            // Mas se tiver mais o ideal é colocar numa classe específica
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
                    //int panA = int.Parse(regSkin["panBacA"].ToString());
                    //int panB = int.Parse(regSkin["panBacB"].ToString());
                    //int panC = int.Parse(regSkin["panBacC"].ToString());
                    int lvA = int.Parse(regSkin["thiBacA"].ToString());
                    int lvB = int.Parse(regSkin["thiBacB"].ToString());
                    int lvC = int.Parse(regSkin["thiBacC"].ToString());
                    this.BackColor = Color.FromArgb(thiBacA, thiBacB, thiBacC);
                    button1.BackColor = Color.FromArgb(lvA, lvB, lvC);
                    button2.BackColor = button1.BackColor;
                    button3.BackColor = button1.BackColor;
                }
            }
        }


    }

}
