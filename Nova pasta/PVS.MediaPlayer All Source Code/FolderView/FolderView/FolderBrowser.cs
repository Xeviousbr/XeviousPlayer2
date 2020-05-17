#region Usings

using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

#endregion

namespace FolderView
{
    public partial class MainWindow
    {
        /*

            Unfortunately, the default Windows FolderBrowserDialog is not very pleasant to work with.
            Therefore, the default folder browser is replaced with an on-screen treeview control.

            I found a brilliant folder treeview control written by Amged Rustom.
            Please have a look at his nice and short article "List Drives and Folders in a TreeView Using C#"
            http://codehill.com/2013/06/list-drives-and-folders-in-a-treeview-using-c/
            Thank you very much, Amged!

            Added search/selection of folders by path/name (SetFolderBrowser/FindFolderBrowserNode),
            a custom treeview sort (FolderBrowserComparer - as used by Windows Explorer) and others.

        */

        #region FolderBrowser Init / BeforeExpand / SetPath / FindNode

        private void FolderBrowser_Init()
        {
            // Set custom sort
            folderBrowser.TreeViewNodeSorter = new FolderBrowserComparer();

            // get a list of the drives
            string[] drives = Environment.GetLogicalDrives();

            foreach (string drive in drives)
            {
                DriveInfo di = new DriveInfo(drive);
                int driveImage;

                switch (di.DriveType)    // set the drive's icon
                {
                    case DriveType.CDRom:
                        driveImage = 3;
                        break;
                    case DriveType.Network:
                        driveImage = 6;
                        break;
                    case DriveType.NoRootDirectory:
                        driveImage = 8;
                        break;
                    case DriveType.Unknown:
                        driveImage = 8;
                        break;
                    default:
                        driveImage = 2;
                        break;
                }

                TreeNode node = new TreeNode(drive.Substring(0, 2), driveImage, driveImage);
                node.Tag = drive;

                if (di.IsReady == true)
                    node.Nodes.Add("...");

                folderBrowser.Nodes.Add(node);
            }
        }

        public void FolderBrowser_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (_dontExpand) // used with double click handling
            {
                _dontExpand = false;
                e.Cancel = true;
                return;
            }

            bool skip = false; // used with don't show 'no access' folders

            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {
                    folderBrowser.BeginUpdate();
                    e.Node.Nodes.Clear();

                    // get the list of sub direcotires
                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());

                    foreach (string dir in dirs)
                    {
                        DirectoryInfo di = new DirectoryInfo(dir);
                        TreeNode node = new TreeNode(di.Name, 0, 1);

                        try
                        {
                            node.Tag = dir;  // keep the directory's full path in the tag for use later
                            // if the directory has any sub directories add the place holder
                            if (di.GetDirectories().Length > 0) node.Nodes.Add(null, "...", 0, 0);
                        }
                        catch (UnauthorizedAccessException)
                        {
                            // if an unauthorized access exception occured display a locked folder
                            //node.ImageIndex = 12;
                            //node.SelectedImageIndex = 12;

                            // replaced with:
                            // if an unauthorized access exception occured don't add the folder
                            skip = true;
                        }
                        catch { /* ignore */ }
                        finally
                        {
                            if (!skip) e.Node.Nodes.Add(node);
                            else skip = false;
                        }
                    }
                    folderBrowser.EndUpdate();
                    folderBrowser.Focus();
                }
            }
        }

        // select and display the treeview node representing the folder specified by 'folderPath'
        private void FolderBrowser_SetPath(string folderPath)
        {
            string[] searchItems = folderPath.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            //searchItems[0] = searchItems[0].TrimEnd(':');

            TreeNodeCollection searchNodes = folderBrowser.Nodes;
            TreeNode currentNode = null;

            for (int i = 0; i < searchItems.Length; i++)
            {
                currentNode = FolderBrowser_FindNode(searchNodes, searchItems[i]);
                if (currentNode == null) { break; }
                else
                {
                    if (i < searchItems.Length - 1)
                    {
                        currentNode.Expand();
                        searchNodes = currentNode.Nodes;
                    }
                }
            }
            if (currentNode != null)
            {
                folderBrowser.SelectedNode = currentNode;
                folderBrowser.Focus();
            }
        }

        // used by FolderBrowser_SetPath
        private TreeNode FolderBrowser_FindNode(TreeNodeCollection nodes, string key)
        {
            TreeNode node = null;
            for (int i = 0; i < nodes.Count; i++)
            {
                if (string.Compare(nodes[i].Text, key, true) == 0)
                {
                    node = nodes[i];
                    break;
                }
            }
            return node;
        }

        #endregion

        #region FolderBrowser Custom Sort

        // Used to sort names with numbers in the 'right' order:
        // e.g. ...1, ...2, ...10 instead of ...1, ...10, ...2
        public class FolderBrowserComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return SafeNativeMethods.StrCmpLogicalW(((TreeNode)x).Text, ((TreeNode)y).Text);
            }
        }

        #endregion

        #region FolderBrowser Buttons / Keys / DoubleClick

        // resize buttons
        private void SplitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
            int width = splitContainer1.Panel1.Width / 2;
            resetButton.Width = width;
            selectButton.Left = resetButton.Right;
            selectButton.Width = resetButton.Width + 1;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            folderBrowser.Focus();
            folderBrowser.BeginUpdate();
            folderBrowser.CollapseAll();
            FolderBrowser_SetPath(_prefs.InitialDirectory);
            folderBrowser.EndUpdate();

            FolderBrowser_HideScrollBar(true);
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (_prefs.InitialDirectory != (string)folderBrowser.SelectedNode.Tag)
            {
                _prefs.InitialDirectory = (string)folderBrowser.SelectedNode.Tag;
                CreateFolderView(_prefs.InitialDirectory);
            }
            folderBrowser.Focus();
        }

        private void FolderBrowser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                selectButton.PerformClick();
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                resetButton.PerformClick();
            }
        }

        private void FolderBrowser_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            selectButton.PerformClick();
            _dontExpand = false;
        }

        private void FolderBrowser_MouseDown(object sender, MouseEventArgs e)
        {
            _dontExpand = e.Clicks > 1;
        }

        #endregion

        #region FolderBrowser ScrollBar Hide / Show / Mouse Events

        // It does not seem possible to hide both scrollbars...

        private void FolderBrowser_MouseLeave(object sender, EventArgs e)
        {
            FolderBrowser_HideScrollBar(false);
        }

        private void FlowLayoutPanel1_MouseEnter(object sender, EventArgs e)
        {
            FolderBrowser_HideScrollBar(false);
        }

        private void FolderBrowser_Enter(object sender, EventArgs e)
        {
            if (Form.ActiveForm == this)
            {
                FolderBrowser_ShowScrollBar();
            }
        }

        private void FolderBrowser_MouseHover(object sender, EventArgs e)
        {
            if (Form.ActiveForm == this)
            {
                FolderBrowser_ShowScrollBar();
            }
        }

        private void FolderBrowser_HideScrollBar(bool force)
        {
            if (!_scrollBarHidden || force)
            {
                if ((SafeNativeMethods.GetWindowLong(folderBrowser.Handle, SafeNativeMethods.GWL_STYLE) & 0x00200000) != 0)
                {
                    SafeNativeMethods.ShowScrollBar(folderBrowser.Handle, SafeNativeMethods.SB_VERT, 0);
                    _scrollBarHidden = true;
                }
            }
        }

        private void FolderBrowser_ShowScrollBar()
        {
            if (_scrollBarHidden)
            {
                SafeNativeMethods.ShowScrollBar(folderBrowser.Handle, SafeNativeMethods.SB_VERT, 1);
                _scrollBarHidden = false;
            }
            folderBrowser.Focus();
        }

        #endregion
    }
}
