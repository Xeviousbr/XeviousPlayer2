#region Usings

using System;
using System.Diagnostics;
using System.Windows.Forms;
using PVS.MediaPlayer;

#endregion

namespace FolderView
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (AlreadyRunning()) return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Player.MFPresent)
            {
                MessageBox.Show("Microsoft Media Foundation\r\n\r\n" + Player.MFPresent_ResultString,
                    "FolderView", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else Application.Run(new MainWindow());
        }

        /// <summary>
        /// Check if an instance of the application is already running.
        /// </summary>
        private static bool AlreadyRunning()
        {
            Process current = Process.GetCurrentProcess();
            foreach (Process process in Process.GetProcessesByName(current.ProcessName))
            {
                if (process.Id != current.Id)
                {
                    if (process.MainWindowHandle != null)
                    {
                        SafeNativeMethods.SetForegroundWindow(process.MainWindowHandle);
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
