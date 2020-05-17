using System;
using System.Windows.Forms;
using PVS.MediaPlayer;

namespace PVSPlayerExample
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

            if (!Player.MFPresent)
            {
                MessageBox.Show("Microsoft Media Foundation\r\n\r\n" + Player.MFPresent_ResultString,
                    MainWindow.APPLICATION_NAME, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else Application.Run(new MainWindow());
        }
    }
}
