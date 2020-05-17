#region Usings

using PVS.MediaPlayer;
using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    /* ******************************** About Slider Preview
    
    Slider Preview
    (this example does not use the PVS.MediaPlayer InfoLabel option) 

    Shows a preview of the playing media (video and/or time) when the mouse is moved over the slider (trackbar) of the player.
    Uses a (second) player to show the video stills.

    Usage:
    1. call 'CreateSliderPreview(myPlayer)' to activate slider preview
    2. call 'StartSliderPreview()' when new media started playing (to adjust preview form to media format etc.)
    3. call 'StopSliderPreview()' when media finishes/stops playing
    4. call 'RemoveSliderPreview()' with application exit (or stop using slider preview) to dispose preview player, form etc.

    */

    public partial class MainWindow
    {
        // ******************************** Slider Preview Fields

        #region Slider Preview Fields

        private const int   SP_IMAGE_SIZE = 132; // music cover size
        private Size        SP_FORM_SIZE = new Size(164, 164); // video size

        private bool        sp_Created;
        private bool        sp_Active;
        private bool        sp_Shown;
        private bool        sp_SkipOnce;
        private bool        sp_Busy;

        private Player      sp_BasePlayer;
        private TrackBar    sp_BaseSlider;
        private Form        sp_BaseForm;
        private int         sp_LastPosX;
        private TimeSpan    sp_Time;
        private Point       sp_Location;

        private Player      sp_Player;
        private bool        sp_HasVideo;

        private class       SP_Form : Form
        {
            const int WS_EX_NOACTIVATE  = 0x08000000;
            const int WS_EX_TOOLWINDOW  = 0x00000080;
            const int WS_EX_TOPMOST     = 0x00000008;
            //const int WS_CHILD          = 0x40000000;
            //const int WS_THICKFRAME     = 0x00040000;

            public SP_Form()
            {
                ShowInTaskbar = false;
                StartPosition = FormStartPosition.Manual;
            }

            protected override bool ShowWithoutActivation
            {
                get { return true; }
            }

            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams ret = base.CreateParams;
                    //ret.Style = WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW | WS_THICKFRAME;
                    ret.Style = WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW;
                    ret.ExStyle |= WS_EX_TOPMOST;
                    return ret;
                }
            }

            protected override void WndProc(ref Message m)
            {
                const int WM_MOUSEACTIVATE = 0x0021;
                const int MA_NOACTIVATEANDEAT = 0x0004;
                const int WM_NCHITTEST = 0x0084;
                const int HTTRANSPARENT = (-1);

                if (m.Msg == WM_MOUSEACTIVATE) m.Result = (IntPtr)MA_NOACTIVATEANDEAT;
                else if (m.Msg == WM_NCHITTEST) m.Result = (IntPtr)HTTRANSPARENT;
                else base.WndProc(ref m);
            }
        }

        private SP_Form     sp_Form;
        private Label       sp_Label;
        private Color       sp_ForeColor        = Color.FromArgb(179, 173, 146);
        private Color       sp_BackColor        = Color.DimGray; // Color.FromArgb(18, 18, 18);
        private Color       sp_LabelBackColor   = Color.FromArgb(18, 18, 18);

        private Metadata    sp_TagInfo;
        private Panel       sp_PicturePanel;


        #endregion

        // ******************************** Slider Preview Main

        #region Slider Preview Main

        private void CreateSliderPreview(Player player)
        {
            if (!sp_Created && player != null && player.Sliders.Position != null)
            {
                sp_BasePlayer           = player;
                sp_BaseSlider           = player.Sliders.Position.TrackBar;
                sp_BaseForm             = sp_BaseSlider.FindForm();

                sp_Form                 = new SP_Form();
                sp_Form.Size            = SP_FORM_SIZE;
                sp_Form.BackColor       = sp_BackColor;

                sp_Label                = new Label();
                sp_Label.BorderStyle    = BorderStyle.FixedSingle;
                sp_Label.BackColor      = sp_LabelBackColor;
                sp_Label.ForeColor      = sp_ForeColor;
                sp_Label.Font           = new Font(sp_Label.Font.FontFamily, 9.8F);
                //sp_Label.Left           = 0;// -1;
                sp_Label.Height         = 23;
                sp_Label.TextAlign      = ContentAlignment.MiddleCenter;
                sp_Label.Text           = "00:00:00.000";
                sp_Form.Controls.Add(sp_Label);

                sp_Player               = new Player();
                sp_Player.Mute          = true;
                sp_Player.Paused        = true;

                sp_Time                 = new TimeSpan();

                sp_Created              = true;
            }
        }

        private void RemoveSliderPreview()
        {
            if (sp_Created)
            {
                StopSliderPreview();

                sp_Player.Dispose();
                sp_Player = null;

                sp_Label.Dispose();
                sp_Label = null;

                sp_Form.Dispose();
                sp_Form = null;

                sp_BasePlayer = null;
                sp_BaseSlider = null;

                sp_Created = false;
            }
        }

        private void StartSliderPreview()
        {
            if (sp_Created)
            {
                if (sp_Active) StopSliderPreview();

                if (sp_BasePlayer.Has.Video)
                {
                    sp_HasVideo                 = true;
                    sp_Player.Display.Window    = sp_Form;
                    sp_Player.Play(sp_BasePlayer.Media.GetName(MediaName.FullPath));

                    Rectangle r = sp_Player.Video.Bounds;
                    sp_Player.Video.Bounds = new Rectangle(1, 1, r.Width, r.Height);
                    sp_Form.Size = r.Size;
                    if (r.Width % 2 == 0) sp_Form.Width += 2;
                    if (r.Height % 2 == 0) sp_Form.Height += 2;

                    sp_Form.Height += sp_Label.Height - 1;
                    sp_Label.Top = sp_Form.ClientRectangle.Height - sp_Label.Height;// - 1;
                    sp_Label.Width = sp_Form.ClientRectangle.Width; // + 2;
                }
                else
                {
                    sp_HasVideo                 = false;
                    sp_Player.Display.Window    = null;

                    sp_TagInfo                  = sp_BasePlayer.Media.GetMetadata();
                    if (sp_TagInfo.Image != null)
                    {
                        int height  = SP_IMAGE_SIZE;
                        int width   = SP_IMAGE_SIZE;

                        if (sp_TagInfo.Image.Height < sp_TagInfo.Image.Width)
                        {
                            height = (int)(sp_TagInfo.Image.Height * ((float)SP_IMAGE_SIZE / sp_TagInfo.Image.Width));
                        }
                        else
                        {
                            width = (int)(sp_TagInfo.Image.Width * ((float)SP_IMAGE_SIZE / sp_TagInfo.Image.Height));
                        }

                        sp_Form.Height                          = height + sp_Label.Height;
                        sp_Form.Width                           = width;

                        sp_PicturePanel                         = new Panel();
                        sp_PicturePanel.BackColor               = Color.FromArgb(18, 18, 18);
                        sp_PicturePanel.Bounds                  = new Rectangle(1, 1, sp_Form.Width - 2, sp_Form.Height - sp_Label.Height - 1);
                        sp_PicturePanel.BackgroundImageLayout   = ImageLayout.Stretch;
                        sp_PicturePanel.BackgroundImage         = sp_TagInfo.Image;
                        sp_Form.Controls.Add(sp_PicturePanel);

                        sp_Label.Top    = sp_Form.ClientRectangle.Height - sp_Label.Height;
                        sp_Label.Width  = sp_Form.ClientRectangle.Width;
                    }
                    else
                    {
                        sp_Form.Width   = SP_IMAGE_SIZE;
                        sp_Form.Height  = sp_Label.Height - 8;
                        sp_Label.Top    = -2;
                        sp_Label.Width  = sp_Form.ClientRectangle.Width + 2;
                        sp_Label.Height = sp_Form.ClientRectangle.Height + 3;
                    }
                }

                // set eventhandlers
                sp_BaseSlider.MouseEnter    += BaseSlider_MouseEnter;
                sp_BaseSlider.MouseLeave    += BaseSlider_MouseLeave;
                sp_BaseSlider.MouseDown     += BaseSlider_MouseDown;
                sp_BaseSlider.MouseUp       += BaseSlider_MouseUp;
                sp_BaseForm.Deactivate      += BaseForm_Deactivate;

                sp_Active = true;
            }
        }

        private void StopSliderPreview()
        {
            if (sp_Active)
            {
                // remove eventhandlers
                sp_BaseSlider.MouseEnter    -= BaseSlider_MouseEnter;
                sp_BaseSlider.MouseLeave    -= BaseSlider_MouseLeave;
                sp_BaseSlider.MouseDown     -= BaseSlider_MouseDown;
                sp_BaseSlider.MouseUp       -= BaseSlider_MouseUp;
                sp_BaseForm.Deactivate      -= BaseForm_Deactivate;

                // close _previewForm
                HideSliderPreview();

                // reset player
                sp_Player.Stop();
                sp_Player.Display.Window    = null;
                sp_Player.Display.Mode      = DisplayMode.ZoomCenter;

                // restore previewform size
                sp_Form.Size                = SP_FORM_SIZE;
                sp_LastPosX                 = 0;

                // remove TagInfo
                if (sp_PicturePanel != null)
                {
                    sp_Form.Controls.Remove(sp_PicturePanel);
                    sp_PicturePanel.BackgroundImage = null;
                    sp_PicturePanel.Dispose();
                    sp_PicturePanel = null;
                }
                if (sp_TagInfo != null)
                {
                    sp_TagInfo.Dispose();
                    sp_TagInfo = null;
                }

                sp_Active = false;
            }
        }

        //private Color SliderPreviewForeColor
        //{
        //    get { return sp_ForeColor; }
        //    set
        //    {
        //        sp_ForeColor = value;
        //        if (sp_Created) sp_Label.ForeColor = value;
        //    }
        //}

        //private Color SliderPreviewBackColor
        //{
        //    get { return sp_BackColor; }
        //    set
        //    {
        //        sp_BackColor = value;
        //        if (sp_Created)
        //        {
        //            sp_Form.BackColor   = value;
        //            sp_Label.BackColor  = value;
        //        }
        //    }
        //}

        #endregion

        // ******************************** Slider Preview Eventhandlers

        #region Slider Preview EventHandlers

        // Show preview when: mouse enters trackbar control, mouse up on trackbar control
        // Hide preview when: mouse leaves trackbar control, mouse down on trackbar control
        // Draw preview when: mouse moves on trackbar control

        // used by eventhandlers
        private void ShowSliderPreview(bool skipOnce)
        {
            if (!sp_Shown && (this == ActiveForm || (sp_BasePlayer.Has.Overlay && sp_BasePlayer.Overlay.Window == ActiveForm)))
            {
                sp_Shown                = true;
                sp_SkipOnce             = skipOnce;
                sp_BaseSlider.MouseMove += BaseSlider_MouseMove;
            }
        }

        // used by eventhandlers
        private void HideSliderPreview()
        {
            if (sp_Shown)
            {
                sp_Shown                = false;
                sp_BaseSlider.MouseMove -= BaseSlider_MouseMove;
                sp_Form.Visible         = false;
            }
        }

        // 'on spot' hide preview (e.g. from timer)
        private void HideSliderPreviewByTimer()
        {
            if (sp_Shown)
            {
                sp_SkipOnce     = true;
                sp_Form.Visible = false;
            }
        }

        private void BaseSlider_MouseEnter(object sender, System.EventArgs e)
        {
            ShowSliderPreview(false);
        }

        private void BaseSlider_MouseLeave(object sender, System.EventArgs e)
        {
            HideSliderPreview();
            sp_LastPosX = 0;
        }

        private void BaseSlider_MouseDown(object sender, MouseEventArgs e)
        {
            HideSliderPreview();
        }

        private void BaseSlider_MouseUp(object sender, MouseEventArgs e)
        {
            ShowSliderPreview(true);
        }

        private void BaseSlider_MouseMove(object sender, MouseEventArgs e)
        {
            // has something to do with order of events raised (?)
            if (MouseButtons == MouseButtons.Left)
            {
                if (sp_Shown) sp_Form.Visible = false;
                return;
            }

            if (sp_BaseForm == ActiveForm && !sp_Busy && !sp_SkipOnce && (Math.Abs(sp_LastPosX - e.X) > 1)) // > 2?
            {
                sp_Busy     = true;
                sp_LastPosX = e.X;

                sp_Time = TimeSpan.FromMilliseconds(SliderValue.FromPoint(sp_BaseSlider, e.Location));
                sp_Label.Text = string.Format("{0:00;00}:{1:00;00}:{2:00;00}.{3:000;000}", sp_Time.Hours, sp_Time.Minutes, sp_Time.Seconds, sp_Time.Milliseconds);

                sp_Location         = sp_BaseSlider.PointToScreen(e.Location);
                sp_Location.X       -= (int)(0.5 * sp_Form.Width);
                sp_Location.Y       = sp_BaseSlider.PointToScreen(Point.Empty).Y - sp_Form.Height - 3;
                sp_Form.Location    = sp_Location;

                // a player only paints video if its display is on-screen
                if (sp_Shown && !sp_Form.Visible)
                {
                    if (sp_HasVideo) sp_Form.Opacity = 0;
                    sp_Form.Visible = true;
                    if (sp_HasVideo)
                    {
                        Application.DoEvents();
                        sp_Player.Position.FromStart = sp_Time;
                        sp_Form.Opacity = 1;
                    }
                }
                else if (sp_HasVideo) sp_Player.Position.FromStart = sp_Time;

                sp_Busy = false;
            }
            sp_SkipOnce = false;
        }

        private void BaseForm_Deactivate(object sender, EventArgs e)
        {
            HideSliderPreviewByTimer();
        }

        #endregion
    }
}

