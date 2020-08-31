using System;
using System.Collections;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

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

    }

}
