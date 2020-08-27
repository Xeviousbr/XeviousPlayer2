using System;
using System.Windows.Forms;
using PVS.MediaPlayer;

// https://www.codeproject.com/Articles/109714/PVS-MediaPlayer-Audio-and-Video-Player-Library

// https://cursos.alura.com.br/forum/topico-subir-um-projeto-existente-para-o-github-64968

/*
[ x ] Ajustar as dimensões

Ajuste do tema visual
[ x ] Identificar as difernças
this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
this.listView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
--------------
this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
[ x ] Elecalas em parametros
    labFor
    panBac
    thiBac
[ x ] Criar uma tabela
     [ x ] Skin
[ x ] Guardar os parametros na tabela
     [ x ] 11775378, 1184274, 3158064
[   ] Ler da tabela ao inicializar
[   ] Setar o visual conforme o parametros
Ao fim a tabela teria 2 registros uma para um tema claro outro para um escuro

[   ] Colocar a barra de cima
[   ] Colocar a foto
[   ] Colocar os dados da musica
[   ] Colocar a grid
[   ] Ajustar o estilo da Grid
[   ] Colocar os botões em baixo
[   ] Utilizar os controles como no exemplo
[   ] Preparar o espaço para a visualização
[   ] Colocar a visualização
[   ] Colocar o recurso de tela inteira
[   ] Colocar o recurso de visualização acoplada
 */


namespace XeviousPlayer2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Check if Media Foundation is installed - you can use this anywhere in your application
            if (!Player.MFPresent)
            {
                // Media Foundation is not installed - show a message and exit the application
                MessageBox.Show ("Microsoft Media Foundation\r\n\r\n" + Player.MFPresent_ResultString + ".",
                    "PVS.MediaPlayer How To ...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                // Media Foundation is installed - run the application
                Application.Run(new Form1());
            }
        }
    }
}
