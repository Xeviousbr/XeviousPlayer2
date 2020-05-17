#region Usings

using PVS.MediaPlayer;
using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    // Clone Window
    // A Form used as a display clone of the main player.


    public partial class CloneWindow : Form
    {
        #region Fields

        private MainWindow      _baseWindow;
        private Player          _basePlayer;
        internal string         CloneTitle;

        private bool            _fullScreen;
        private FormWindowState _oldWindowState;

        private CloneLayout     _cloneLayout        = CloneLayout.Zoom;
        //private bool            _stretchMode;
        private DisplayShape    _cloneShape         = DisplayShape.Normal;
        private CloneProperties _cloneProperties;

        private bool            _hasTaskbarProgress = true;

        #endregion

        // ******************************** Main / Eventhandlers

        #region Main / Eventhandlers

        public CloneWindow(MainWindow mainWindow, Player player, string title)
        {
            InitializeComponent();

            this.ClientSize = new Size(640, 480);

            _baseWindow     = mainWindow;
            _basePlayer     = player;
            CloneTitle      = title;

            _basePlayer.CursorHide.Add(this);

            KeyPreview      = true;
            KeyDown         += CloneWindow_KeyDown;

            if (_baseWindow == null)
            {
                // remove "Main Window" item + separator
                int count = cloneWindowMenu.Items.Count - 2;
                cloneWindowMenu.Items.RemoveAt(count);
                cloneWindowMenu.Items.RemoveAt(--count);
                //hideMainWindowMenuItem.Enabled = false;
            }
            else ((ToolStripDropDownMenu)hideMainWindowMenuItem.DropDown).ShowImageMargin = false;
        }

        private void CloneWindow_Shown(object sender, EventArgs e)
        {
            // this is here because the form must me created (in the constructor above) before
            // any properties can be set:
            _cloneProperties = new CloneProperties();
            _cloneProperties.DragEnabled = true;
            _basePlayer.DisplayClones.SetProperties(this, _cloneProperties);

            if (_hasTaskbarProgress) _basePlayer.TaskbarProgress.Add(this);
        }

        private void CloneWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (_fullScreen && e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                fullScreenMenuItem.PerformClick();
            }
        }

        private void CloneWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_basePlayer != null && _hasTaskbarProgress) _basePlayer.TaskbarProgress.Remove(this);

            // should also signal webcam window
            if (_baseWindow != null)
            {
                _baseWindow.CloneWindows_Remove(this);

                if (_baseWindow.Opacity == 0 && _basePlayer.DisplayClones.Count == 0)
                {
                    _baseWindow.Opacity = 1;
                    if (_basePlayer.Has.Overlay) _basePlayer.Overlay.Window.Opacity = 1;
                }
            }
        }

        #endregion

        // ******************************** Context Menu Handling

        #region Context Menu Handling

        #region Display Mode

        private void ZoomMenuItem_Click(object sender, System.EventArgs e)
        {
            if (_cloneLayout != CloneLayout.Zoom)
            {
                _cloneProperties.Layout = CloneLayout.Zoom;
                _basePlayer.DisplayClones.SetProperties(this, _cloneProperties);

                zoomMenuItem.Checked        = true;
                coverMenuItem.Checked       = false;
                stretchMenuItem.Checked     = false;
                displayModeMenuItem.Checked = false;
                _cloneLayout                = CloneLayout.Zoom;
            }
        }

        private void CoverMenuItem_Click(object sender, EventArgs e)
        {
            if (_cloneLayout != CloneLayout.Cover)
            {
                _cloneProperties.Layout = CloneLayout.Cover;
                _basePlayer.DisplayClones.SetProperties(this, _cloneProperties);

                zoomMenuItem.Checked        = false;
                coverMenuItem.Checked       = true;
                stretchMenuItem.Checked     = false;
                displayModeMenuItem.Checked = true;
                _cloneLayout                = CloneLayout.Cover;
            }
        }

        private void StretchMenuItem_Click(object sender, System.EventArgs e)
        {
            if (_cloneLayout != CloneLayout.Stretch)
            {
                _cloneProperties.Layout = CloneLayout.Stretch;
                _basePlayer.DisplayClones.SetProperties(this, _cloneProperties);

                zoomMenuItem.Checked        = false;
                coverMenuItem.Checked       = false;
                stretchMenuItem.Checked     = true;
                displayModeMenuItem.Checked = true;
                _cloneLayout                = CloneLayout.Stretch;
            }
        }

        #endregion

        #region Flip Mode

        private void FlipXMenuItem_Click(object sender, EventArgs e)
        {
            _cloneProperties.Flip = CloneFlip.FlipX;
            _basePlayer.DisplayClones.SetProperties(this, _cloneProperties);
            SetFlipMode(flipXMenuItem);
        }

        private void FlipXYMenuItem_Click(object sender, EventArgs e)
        {
            _cloneProperties.Flip = CloneFlip.FlipXY;
            _basePlayer.DisplayClones.SetProperties(this, _cloneProperties);
            SetFlipMode(flipXYMenuItem);
        }

        private void FlipYMenuItem_Click(object sender, EventArgs e)
        {
            _cloneProperties.Flip = CloneFlip.FlipY;
            _basePlayer.DisplayClones.SetProperties(this, _cloneProperties);
            SetFlipMode(flipYMenuItem);
        }

        private void FlipNoneMenuItem_Click(object sender, EventArgs e)
        {
            _cloneProperties.Flip = CloneFlip.FlipNone;
            _basePlayer.DisplayClones.SetProperties(this, _cloneProperties);
            SetFlipMode(flipNoneMenuItem);
        }

        private void SetFlipMode(ToolStripMenuItem setItem)
        {
            flipXMenuItem.Checked       = false;
            flipXYMenuItem.Checked      = false;
            flipYMenuItem.Checked       = false;
            flipNoneMenuItem.Checked    = false;

            setItem.Checked             = true;
            flipModeMenuItem.Checked    = setItem != flipNoneMenuItem;
        }

        #endregion

        #region Quality Mode

        private void NormalQualityMenuItem_Click(object sender, System.EventArgs e)
        {
            normalQualityMenuItem.Checked   = true;
            highQualityMenuItem.Checked     = false;
            cloneQualityMenuItem.Checked    = false;
            _cloneProperties.Quality        = CloneQuality.Auto;
            _basePlayer.DisplayClones.SetProperties(this, _cloneProperties);
        }

        private void HighQualityMenuItem_Click(object sender, System.EventArgs e)
        {
            normalQualityMenuItem.Checked   = false;
            highQualityMenuItem.Checked     = true;
            cloneQualityMenuItem.Checked    = true;
            _cloneProperties.Quality        = CloneQuality.High;
            _basePlayer.DisplayClones.SetProperties(this, _cloneProperties);
        }

        #endregion

        #region Opacity

        private void Opacity25MenuItem_Click(object sender, EventArgs e)
        {
            Opacity = 0.25;
            SetOpacityMenu(sender);
        }

        private void Opacity50MenuItem_Click(object sender, EventArgs e)
        {
            Opacity = 0.5;
            SetOpacityMenu(sender);
        }

        private void Opacity75MenuItem_Click(object sender, EventArgs e)
        {
            Opacity = 0.75;
            SetOpacityMenu(sender);
        }

        private void Opacity100MenuItem_Click(object sender, EventArgs e)
        {
            Opacity = 1;
            SetOpacityMenu(sender);
        }

        // Checks the selected Opacity menu item and removes the check marks from the others
        private void SetOpacityMenu(object sender)
        {
            foreach (ToolStripItem item in (((ToolStripMenuItem)sender).GetCurrentParent().Items))
            {
                if (item.GetType() == typeof(ToolStripMenuItem))
                {
                    ((ToolStripMenuItem)item).Checked = item == sender;
                }
            }
            opacityMenuItem.Checked = (Opacity != 1);
        }

        #endregion

        #region FullScreen

        private void FullScreenMenuItem_Click(object sender, EventArgs e)
        {
            _fullScreen = !_fullScreen;
            fullScreenMenuItem.Checked = _fullScreen;

            if (_fullScreen)
            {
                _oldWindowState = WindowState;
                if (WindowState == FormWindowState.Maximized) WindowState = FormWindowState.Normal;

                if (_cloneShape == DisplayShape.Normal) FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                if (_cloneShape == DisplayShape.Normal) FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = _oldWindowState;
            }
        }

        #endregion

        #region Show In Taskbar / Always On Top

        private void ShowInTaskbarMenuItem_Click(object sender, System.EventArgs e)
        {
            showInTaskbarMenuItem.Checked = !showInTaskbarMenuItem.Checked;
            ShowInTaskbar = showInTaskbarMenuItem.Checked;

            _hasTaskbarProgress = showInTaskbarMenuItem.Checked;
            if (_hasTaskbarProgress) _basePlayer.TaskbarProgress.Add(this);
            else _basePlayer.TaskbarProgress.Remove(this);
        }

        private void AlwaysOnTopMenuItem_Click(object sender, System.EventArgs e)
        {
            alwaysOnTopMenuItem.Checked = !alwaysOnTopMenuItem.Checked;
            TopMost = alwaysOnTopMenuItem.Checked;
        }

        #endregion

        #region Main Window

        private void HideMainWindowMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (_baseWindow.Opacity > 0)
            {
                hideWindowMenuItem.Enabled = true;
                showWindowMenuItem.Enabled = false;
            }
            else
            {
                hideWindowMenuItem.Enabled = false;
                showWindowMenuItem.Enabled = true;
            }
        }

        private void HideWindowMenuItem_Click(object sender, EventArgs e)
        {
            _baseWindow.Opacity = 0;
            if (_basePlayer.Has.Overlay) _basePlayer.Overlay.Window.Opacity = 0;
        }

        private void ShowWindowMenuItem_Click(object sender, EventArgs e)
        {
            _baseWindow.Opacity = 1;
            _baseWindow.Activate();
            if (_basePlayer.Has.Overlay) _basePlayer.Overlay.Window.Opacity = 1;
        }

        #endregion

        #region Close

        private void CloseMenuItem_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        #endregion

        #endregion

        // ******************************** Set Display Shapes - Shape Menu

        #region Set Display Shapes - Shape Menu

        private void SetDisplayShape(ToolStripMenuItem menuItem, DisplayShape shape)
        {
            if (shape != _cloneShape)
            {
                // set form border
                if (shape == DisplayShape.Normal)
                {
                    if (_cloneShape != DisplayShape.Normal)
                    {
                        if (!_fullScreen) FormBorderStyle = FormBorderStyle.Sizable;
                        //TransparencyKey = Color.Empty;
                        BackColor = Color.FromArgb(18, 18, 18);

                        if (Region != null)
                        {
                            Region.Dispose();
                            Region = null;
                        }
                    }
                }
                else
                {
                    if (_cloneShape == DisplayShape.Normal)
                    {
                        //TransparencyKey = Color.Lime;
                        BackColor = Color.Lime;
                        if (!_fullScreen) FormBorderStyle = FormBorderStyle.None;

                        normalShapeMenuItem.Checked = false;
                    }
                }

                // uncheck menu items
                for (int i = 0; i < 23; i++)
                {
                    ((ToolStripMenuItem)displayShapeMenuItem.DropDown.Items[i]).Checked = false;
                }
                menuItem.Checked = true;
                displayShapeMenuItem.Checked = !normalShapeMenuItem.Checked;

                // set form shape
                _cloneShape             = shape;
                _cloneProperties.Shape  = shape;
                _basePlayer.DisplayClones.SetProperties(this, _cloneProperties);
            }
        }

        private void ArrowDownShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(arrowDownShapeMenuItem, DisplayShape.ArrowDown);
        }

        private void ArrowLeftShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(arrowLeftShapeMenuItem, DisplayShape.ArrowLeft);
        }

        private void ArrowRightShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(arrowRightShapeMenuItem, DisplayShape.ArrowRight);
        }

        private void ArrowUpShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(arrowUpShapeMenuItem, DisplayShape.ArrowUp);
        }

        private void BarsShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(barsShapeMenuItem, DisplayShape.Bars);
        }

        private void BeamsShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(beamsShapeMenuItem, DisplayShape.Beams);
        }

        private void CircleShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(circleShapeMenuItem, DisplayShape.Circle);
        }

        private void CrossShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(crossShapeMenuItem, DisplayShape.Cross);
        }

        private void DiamondShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(diamondShapeMenuItem, DisplayShape.Diamond);
        }

        private void FrameShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(frameShapeMenuItem, DisplayShape.Frame);
        }

        private void HeartShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(heartShapeMenuItem, DisplayShape.Heart);
        }

        private void HexagonShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(hexagonalShapeMenuItem, DisplayShape.Hexagon);
        }

        private void OvalShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(ovalShapeMenuItem, DisplayShape.Oval);
        }

        private void RectangleShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(rectangleShapeMenuItem, DisplayShape.Rectangle);
        }

        private void RingShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(ringShapeMenuItem, DisplayShape.Ring);
        }

        private void RoundedShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(roundedShapeMenuItem, DisplayShape.Rounded);
        }

        private void SquareShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(squareShapeMenuItem, DisplayShape.Square);
        }

        private void StarShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(starShapeMenuItem, DisplayShape.Star);
        }

        private void TilesShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(tilesShapeMenuItem, DisplayShape.Tiles);
        }

        private void TriangleDownMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(triangleDownMenuItem, DisplayShape.TriangleDown);
        }

        private void TriangleLeftMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(triangleLeftMenuItem, DisplayShape.TriangleLeft);
        }

        private void TriangleRightMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(triangleRightMenuItem, DisplayShape.TriangleRight);
        }

        private void TriangleUpMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(triangleUpMenuItem, DisplayShape.TriangleUp);
        }

        private void NormalShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(normalShapeMenuItem, DisplayShape.Normal);
        }

        #endregion

    }
}
