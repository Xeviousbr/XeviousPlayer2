#region Usings

using System.Collections.Generic;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    // Display Clones
    // Forms with display clones of the main player.

    public partial class MainWindow
    {
        #region Display Clones Fields

        private bool _hasCloneWindows;
        private List<CloneWindow> _cloneWindows;
        private int _idNumber = 1;

        #endregion

        private void CloneWindows_Add()
        {
            if (_cloneWindows == null)
            {
                _cloneWindows = new List<CloneWindow>(8);
            }

            CloneWindow cloneWindow = new CloneWindow(this, Player1, "#" + _idNumber++.ToString("00") + ": ");
            cloneWindow.Text = cloneWindow.CloneTitle + Text;

            _cloneWindows.Add(cloneWindow);
            Player1.DisplayClones.Add(cloneWindow);

            removeAllClonesMenuItem.Enabled = true;
            _hasCloneWindows = true;

            //cloneWindow.Show(this); // in doubt because of overlay canfocus gets in front of clones
            cloneWindow.Show();
        }

        // This is called by the clone windows when closing
        internal void CloneWindows_Remove(CloneWindow window)
        {
            if (_hasCloneWindows)
            {
                for (int index = 0; index < _cloneWindows.Count; index++)
                {
                    if (_cloneWindows[index] == window)
                    {
                        Player1.DisplayClones.Remove(window);
                        _cloneWindows.RemoveAt(index);
                        break;
                    }
                }

                if (_cloneWindows.Count == 0)
                {
                    removeAllClonesMenuItem.Enabled = false;
                    _idNumber = 1;
                    _hasCloneWindows = false;
                }
            }
        }

        private void CloneWindows_SetTitle(string title)
        {
            if (_hasCloneWindows)
            {
                for (int index = 0; index < _cloneWindows.Count; index++)
                {
                    _cloneWindows[index].Text = _cloneWindows[index].CloneTitle + title;
                }
            }
        }

        private void CloneWindows_SetVisibility(bool visible)
        {
            if (_hasCloneWindows)
            {
                for (int index = 0; index < _cloneWindows.Count; index++)
                {
                    _cloneWindows[index].Visible = visible;
                }
            }
        }

        // closing clone window call CloneWindows_Remove to clean up
        private void CloneWindows_CloseAll()
        {
            if (_hasCloneWindows)
            {
                // handled in CloneWindows_Remove
                while (_cloneWindows.Count > 0)
                {
                    _cloneWindows[0].Close();
                }
            }
        }
    }
}
