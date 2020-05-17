#region Usings

using System;
using System.Collections.Generic;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    // AddUrl dialog - allows urls (http://... etc. links) to be added to the playlist.

    public partial class AddUrlDialog : Form
    {
        #region Fields

        private MainWindow  _baseForm;
        private double      _oldOpacity;

        #endregion


        public AddUrlDialog(MainWindow theBaseForm)
        {
            InitializeComponent();
            Icon = Properties.Resources.Media_Normal;

            _baseForm = theBaseForm;
            _baseForm._urlAdded = false;

            _oldOpacity = Opacity;
            Opacity = 0;

        }

        private void AddURLDialog_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            System.Threading.Thread.Sleep(50);
            Opacity = _oldOpacity;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            GetUrLs();
            this.Visible = false;
            _baseForm = null;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _baseForm = null;
            Close();
        }

        // Get the URLs and add them to the playlist
        private void GetUrLs()
        {
            List<string> urls = new List<string>();

            foreach (string item in textBoxURLs.Lines)
            {
                string testString = item.Trim();
                for (int i = 0; i < _baseForm.STREAMING_URLS.Length; i++)
                {
                    if (testString.StartsWith(_baseForm.STREAMING_URLS[i], StringComparison.OrdinalIgnoreCase))
                    {
                        urls.Add(testString);
                        break;
                    }
                }
            }
            if (urls.Count > 0)
            {
                _baseForm._urlToPlay = _baseForm.Playlist.Count;
                _baseForm.AddToPlayList(urls.ToArray());
                _baseForm._urlAdded = true;
            }
        }

    }
}
