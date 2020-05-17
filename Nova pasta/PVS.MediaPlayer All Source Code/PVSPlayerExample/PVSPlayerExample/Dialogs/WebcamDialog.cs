#region Usings

using System;
using System.Drawing;
using System.Windows.Forms;
using PVS.MediaPlayer;

#endregion

namespace PVSPlayerExample
{
    public partial class WebcamDialog : Form
    {
        #region Fields

        private const int   UPDATE_TIMER_INTERVAL = 1000;   // milliseconds

        private Player      _basePlayer;

        private Timer       _updateTimer;
        private bool        _timerSkip;
        private bool        _getPropertiesBusy;

        private bool        _ignoreCheckBox;
        private bool        _controlsSet;                   // prevent replacing checkboxes multiple times
            
        private double      _oldOpacity;
        private bool        _disposed;

        #endregion


        #region Main

        public WebcamDialog(Player basePlayer)
        {
            InitializeComponent();

            _basePlayer = basePlayer;

            Icon = Properties.Resources.Media_Normal;
            Text += _basePlayer.Webcam.Device.Name; // or _basePlayer.Media.GetName

            _oldOpacity = Opacity;
            Opacity = 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                if (disposing)
                {

                    if (_updateTimer != null) _updateTimer.Dispose();
                    _basePlayer = null;

                    if (components != null) components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Form Event Handlers / Buttons / Property ContextMenu

        private void WebcamDialog_Shown(object sender, EventArgs e)
        {
            GetProperties();

            // set property handlers

            _basePlayer.Events.MediaEndedNotice += BasePlayer_MediaEndedNotice;

            _updateTimer = new Timer();
            _updateTimer.Interval = UPDATE_TIMER_INTERVAL;
            _updateTimer.Tick += UpdateTimer_Tick;
            _timerSkip = true;
            _updateTimer.Start();

            Application.DoEvents();
            System.Threading.Thread.Sleep(75);

            Opacity = _oldOpacity;
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (_timerSkip)
            {
                _timerSkip = false;
            }
            else
            {
                GetProperties();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(109, 103, 76), 1);
            Rectangle rect = DisplayRectangle;
            rect.Width -= 1;
            rect.Height -= 1;
            e.Graphics.DrawRectangle(pen, rect);
            //int xPos = (int)(Width * 0.5) - 3;
            //e.Graphics.DrawLine(pen, xPos, 0, xPos, Height - 80);
            pen.Dispose();
        }

        private void PVSLogo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.PVSLogoOutline, 4, 0);
        }

        private void WebcamDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            _updateTimer.Stop();
            _basePlayer.Events.MediaEndedNotice -= BasePlayer_MediaEndedNotice;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            _timerSkip = true;
            ResetProperties();
            OKButton.Focus();
            _timerSkip = true;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PropertyMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ContextMenuStrip menu = sender as ContextMenuStrip;
            if (menu != null)
            {
                Control control = menu.SourceControl;
                if (control != null && control.Enabled && control.ForeColor != Color.DimGray)
                {
                    ToolStripItem item = menu.Items[0];
                    item.Text = "Reset ";

                    switch (Convert.ToInt32(control.Tag))
                    {
                        case 1: item.Text += "Brightness"; break;
                        case 2: item.Text += "Contrast"; break;
                        case 3: item.Text += "Hue"; break;
                        case 4: item.Text += "Saturation"; break;

                        case 5: item.Text += "Sharpness"; break;
                        case 6: item.Text += "Gamma"; break;
                        case 7: item.Text += "White Balance"; break;
                        case 8: item.Text += "Gain"; break;

                        case 9: item.Text += "Zoom"; break;
                        case 10: item.Text += "Focus"; break;
                        case 11: item.Text += "Exposure"; break;
                        case 12: item.Text += "Iris"; break;

                        case 13: item.Text += "Pan"; break;
                        case 14: item.Text += "Tilt"; break;
                        case 15: item.Text += "Roll"; break;

                        case 16: item.Text += "Flash"; break;
                        case 17: item.Text += "Backlight Compensation"; break;
                        case 18: item.Text += "Color Enable"; break;
                        case 19: item.Text += "Power Line Frequency"; break;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void ResetMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            if (item != null)
            {
                ContextMenuStrip menu = item.Owner as ContextMenuStrip;
                if (menu != null)
                {
                    Control control = menu.SourceControl;
                    if (control != null)
                    {
                        WebcamProperty property = null;

                        switch (Convert.ToInt32(control.Tag))
                        {
                            case 1: property = _basePlayer.Webcam.Brightness; break;
                            case 2: property = _basePlayer.Webcam.Contrast; break;
                            case 3: property = _basePlayer.Webcam.Hue; break;
                            case 4: property = _basePlayer.Webcam.Saturation; break;

                            case 5: property = _basePlayer.Webcam.Sharpness; break;
                            case 6: property = _basePlayer.Webcam.Gamma; break;
                            case 7: property = _basePlayer.Webcam.WhiteBalance; break;
                            case 8: property = _basePlayer.Webcam.Gain; break;

                            case 9: property = _basePlayer.Webcam.Zoom; break;
                            case 10: property = _basePlayer.Webcam.Focus; break;
                            case 11: property = _basePlayer.Webcam.Exposure; break;
                            case 12: property = _basePlayer.Webcam.Iris; break;

                            case 13: property = _basePlayer.Webcam.Pan; break;
                            case 14: property = _basePlayer.Webcam.Tilt; break;
                            case 15: property = _basePlayer.Webcam.Roll; break;

                            case 16: property = _basePlayer.Webcam.Flash; break;
                            case 17: property = _basePlayer.Webcam.BacklightCompensation; break;
                            case 18: property = _basePlayer.Webcam.ColorEnable; break;
                            case 19: property = _basePlayer.Webcam.PowerLineFrequency; break;
                        }

                        if (property != null)
                        {
                            _basePlayer.Webcam.ResetProperty(property);
                            for (int i = 0; i < 2; i++)
                            {
                                Application.DoEvents(); System.Threading.Thread.Sleep(200);
                                Application.DoEvents(); System.Threading.Thread.Sleep(200);
                                Application.DoEvents(); GetProperties();
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #region Player Event Handlers

        private void BasePlayer_MediaEndedNotice(object sender, EndedEventArgs e)
        {
            Close();
        }

        #endregion

        #region Control Event Handlers

        private void ScrollProperty(WebcamProperty prop, CustomSlider2 slider, Label label, CheckBox box)
        {
            _timerSkip = true;

            _basePlayer.Webcam.SetProperty(prop, slider.Value, false);
            label.Text = slider.Value.ToString(); label.Refresh();
            if (box.Visible && box.Checked)
            {
                _ignoreCheckBox = true;
                box.Checked = false;
                _ignoreCheckBox = false;
            }
        }

        // now only used by White Balance - maybe use for all
        private void ScrollPropertyStep(WebcamProperty prop, CustomSlider2 slider, Label label, CheckBox box)
        {
            _timerSkip = true;

            int value = slider.Value * prop.StepSize;
            _basePlayer.Webcam.SetProperty(prop, value, false);
            label.Text = value.ToString(); label.Refresh();
            if (box.Visible && box.Checked)
            {
                _ignoreCheckBox = true;
                box.Checked = false;
                _ignoreCheckBox = false;
            }
        }

        private void CheckedProperty(WebcamProperty prop, int value, CheckBox box)
        {
            if (!_ignoreCheckBox)
            {
                box.Refresh();
                _basePlayer.Webcam.SetProperty(prop, value, box.Checked);
            }
        }

        // now only used by White Balance - maybe use for all
        private void CheckedPropertyStep(WebcamProperty prop, int value, CheckBox box)
        {
            if (!_ignoreCheckBox)
            {
                box.Refresh();
                _basePlayer.Webcam.SetProperty(prop, value * prop.StepSize, box.Checked);
            }
        }

        // some properties may never have a checkbox (automatic control) but you never know...
        private void BrightnessSlider_Scroll(object sender, EventArgs e) { ScrollProperty(_basePlayer.Webcam.Brightness, brightnessSlider, brightnessValue, brightnessBox); }
        private void BrightnessBox_CheckedChanged(object sender, EventArgs e) { CheckedProperty(_basePlayer.Webcam.Brightness, brightnessSlider.Value, brightnessBox); }
        
        private void ContrastSlider_Scroll(object sender, EventArgs e) { ScrollProperty(_basePlayer.Webcam.Contrast, contrastSlider, contrastValue, contrastBox); }
        private void ContrastSlider_CheckedChanged(object sender, EventArgs e) { CheckedProperty(_basePlayer.Webcam.Contrast, contrastSlider.Value, contrastBox); }

        private void HueSlider_Scroll(object sender, EventArgs e) { ScrollProperty(_basePlayer.Webcam.Hue, hueSlider, hueValue, hueBox); }
        private void HueBox_CheckedChanged(object sender, EventArgs e) { CheckedProperty(_basePlayer.Webcam.Hue, hueSlider.Value, hueBox); }

        private void SaturationSlider_Scroll(object sender, EventArgs e) { ScrollProperty(_basePlayer.Webcam.Saturation, saturationSlider, saturationValue, saturationBox); }
        private void SaturationBox_CheckedChanged(object sender, EventArgs e) { CheckedProperty(_basePlayer.Webcam.Saturation, saturationSlider.Value, saturationBox); }

        private void SharpnessSlider_Scroll(object sender, EventArgs e) { ScrollProperty(_basePlayer.Webcam.Sharpness, sharpnessSlider, sharpnessValue, sharpnessBox); }
        private void SharpnessBox_CheckedChanged(object sender, EventArgs e) { CheckedProperty(_basePlayer.Webcam.Sharpness, sharpnessSlider.Value, sharpnessBox); }
        
        private void GammaSlider_Scroll(object sender, EventArgs e) { ScrollProperty(_basePlayer.Webcam.Gamma, gammaSlider, gammaValue, gammaBox); }
        private void GammaBox_CheckedChanged(object sender, EventArgs e) { CheckedProperty(_basePlayer.Webcam.Gamma, gammaSlider.Value, gammaBox); }

        private void WhiteBalanceSlider_Scroll(object sender, EventArgs e) { ScrollPropertyStep(_basePlayer.Webcam.WhiteBalance, whiteBalanceSlider, whiteBalanceValue, whiteBalanceBox); }
        private void WhiteBalanceBox_CheckedChanged(object sender, EventArgs e) { CheckedPropertyStep(_basePlayer.Webcam.WhiteBalance, whiteBalanceSlider.Value, whiteBalanceBox); }

        private void GainSlider_Scroll(object sender, EventArgs e) { ScrollProperty(_basePlayer.Webcam.Gain, gainSlider, gainValue, gainBox); }
        private void GainBox_CheckedChanged(object sender, EventArgs e) { CheckedProperty(_basePlayer.Webcam.Gain, gainSlider.Value, gainBox); }


        private void ZoomSlider_Scroll(object sender, EventArgs e) { ScrollProperty(_basePlayer.Webcam.Zoom, zoomSlider, zoomValue, zoomBox); }
        private void ZoomBox_CheckedChanged(object sender, EventArgs e) { CheckedProperty(_basePlayer.Webcam.Zoom, zoomSlider.Value, zoomBox); }

        private void FocusSlider_Scroll(object sender, EventArgs e) { ScrollProperty(_basePlayer.Webcam.Focus, focusSlider, focusValue, focusBox); }
        private void FocusBox_CheckedChanged(object sender, EventArgs e) { CheckedProperty(_basePlayer.Webcam.Focus, focusSlider.Value, focusBox); }

        private void ExposureSlider_Scroll(object sender, EventArgs e) { ScrollProperty(_basePlayer.Webcam.Exposure, exposureSlider, exposureValue, exposureBox); }
        private void ExposureBox_CheckedChanged(object sender, EventArgs e) { if (!_ignoreCheckBox) { CheckedProperty(_basePlayer.Webcam.Exposure, exposureSlider.Value,  exposureBox); } }

        private void IrisSlider_Scroll(object sender, EventArgs e) { ScrollProperty(_basePlayer.Webcam.Iris, irisSlider, irisValue, irisBox); }
        private void IrisBox_CheckedChanged(object sender, EventArgs e) { CheckedProperty(_basePlayer.Webcam.Iris, irisSlider.Value, irisBox); }


        private void PanSlider_Scroll(object sender, EventArgs e) { ScrollProperty(_basePlayer.Webcam.Pan, panSlider, panValue, panBox); }
        private void PanBox_CheckedChanged(object sender, EventArgs e) { CheckedProperty(_basePlayer.Webcam.Pan, panSlider.Value, panBox); }

        private void TiltSlider_Scroll(object sender, EventArgs e) { ScrollProperty(_basePlayer.Webcam.Tilt, tiltSlider, tiltValue, tiltBox); }
        private void TiltBox_CheckedChanged(object sender, EventArgs e) { CheckedProperty(_basePlayer.Webcam.Tilt, tiltSlider.Value, tiltBox); }

        private void RollSlider_Scroll(object sender, EventArgs e) { ScrollProperty(_basePlayer.Webcam.Roll, rollSlider, rollValue, rollBox); }
        private void RollBox_CheckedChanged(object sender, EventArgs e) { CheckedProperty(_basePlayer.Webcam.Roll, rollSlider.Value, rollBox); }

        private void FlashLabel_Click(object sender, EventArgs e) { flashBox.Checked = !flashBox.Checked; }
        private void FlashBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!_ignoreCheckBox)
            {
                _basePlayer.Webcam.SetProperty(_basePlayer.Webcam.Flash, flashBox.Checked ? 1 : 0, false);
                if (autoFlashBox.Visible)
                {
                    _ignoreCheckBox = true;
                    autoFlashBox.Checked = flashBox.Checked;
                    _ignoreCheckBox = false;
                }
            }
        }
        private void AutoFlashBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!_ignoreCheckBox)
            {
                _basePlayer.Webcam.SetProperty(_basePlayer.Webcam.Flash, 0, autoFlashBox.Checked);
                _ignoreCheckBox = true;
                flashBox.Checked = autoFlashBox.Checked;
                _ignoreCheckBox = false;
            }
        }

        private void BacklightLabel_Click(object sender, EventArgs e) { backlightBox.Checked = !backlightBox.Checked; }
        private void BacklightBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!_ignoreCheckBox)
            {
                _basePlayer.Webcam.SetProperty(_basePlayer.Webcam.BacklightCompensation, backlightBox.Checked ? 1 : 0, false);
                if (autoBacklightBox.Visible)
                {
                    _ignoreCheckBox = true;
                    autoBacklightBox.Checked = backlightBox.Checked;
                    _ignoreCheckBox = false;
                }
            }
        }
        private void AutoBacklightBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!_ignoreCheckBox)
            {
                _basePlayer.Webcam.SetProperty(_basePlayer.Webcam.BacklightCompensation, 0, autoBacklightBox.Checked);
                _ignoreCheckBox = true;
                backlightBox.Checked = autoBacklightBox.Checked;
                _ignoreCheckBox = false;
            }
        }

        private void ColorEnableLabel_Click(object sender, EventArgs e) { colorEnableBox.Checked = !colorEnableBox.Checked; }
        private void ColorEnableBox_CheckedChanged(object sender, EventArgs e) { if (!_ignoreCheckBox) { _basePlayer.Webcam.SetProperty(_basePlayer.Webcam.ColorEnable, colorEnableBox.Checked ? 1 : 0, false); } }

        private void powerLineLabel_Click(object sender, EventArgs e) { powerLineBox.Checked = !powerLineBox.Checked; }
        private void PowerLineBox_CheckedChanged(object sender, EventArgs e) { if (!_ignoreCheckBox) { _basePlayer.Webcam.SetProperty(_basePlayer.Webcam.PowerLineFrequency, powerLineBox.Checked ? 1 : 0, false); } }
        private void Hz50Box_CheckedChanged(object sender, EventArgs e)
        {
            if (!_ignoreCheckBox)
            {
                _ignoreCheckBox = true;

                if (hz50Box.Checked)
                {
                    hz60Box.Checked = false;
                    _basePlayer.Webcam.SetProperty(_basePlayer.Webcam.PowerLineFrequency, 1, false);
                }
                else
                {
                    hz50Box.Checked = true;
                }

                _ignoreCheckBox = false;
            }
        }
        private void Hz60Box_CheckedChanged(object sender, EventArgs e)
        {
            if (!_ignoreCheckBox)
            {
                _ignoreCheckBox = true;

                if (hz60Box.Checked)
                {
                    hz50Box.Checked = false;
                    _basePlayer.Webcam.SetProperty(_basePlayer.Webcam.PowerLineFrequency, 2, false);
                }
                else
                {
                    hz60Box.Checked = true;
                }

                _ignoreCheckBox = false;
            }
        }

        #endregion

        #region Properties

        private void SetPropertyControls(WebcamProperty prop, Label label, CustomSlider2 slider, Label value, CheckBox box)
        {
            if (prop.Supported)
            {
                slider.Minimum = prop.Minimum;
                slider.Maximum = prop.Maximum;
                slider.Value = prop.Value;
                value.Text = prop.Value.ToString();

                if (box != null)
                {
                    if (!prop.AutoSupport)
                    {
                        if (!_controlsSet) DisableCheckBox(box);
                    }
                    else
                    {
                        _ignoreCheckBox = true;
                        box.Checked = prop.AutoEnabled;
                        _ignoreCheckBox = false;
                    }
                }
            }
            else
            {
                if (!_controlsSet)
                {
                    label.ForeColor = Color.DimGray;
                    slider.Enabled = false;
                    value.ForeColor = Color.DimGray;
                    if (box != null) DisableCheckBox(box);
                }
            }
        }

        // with stepsize - only for white balance, or use for all/more?
        private void SetPropertyControlsStep(WebcamProperty prop, Label label, CustomSlider2 slider, Label value, CheckBox box)
        {
            if (prop.Supported)
            {
                int step = prop.StepSize;
                slider.Minimum = prop.Minimum / step;
                slider.Maximum = prop.Maximum / step;
                slider.Value = prop.Value / step;
                value.Text = prop.Value.ToString();

                if (box != null)
                {
                    if (!prop.AutoSupport)
                    {
                        if (!_controlsSet) DisableCheckBox(box);
                    }
                    else
                    {
                        _ignoreCheckBox = true;
                        box.Checked = prop.AutoEnabled;
                        _ignoreCheckBox = false;
                    }
                }
            }
            else
            {
                if (!_controlsSet)
                {
                    label.ForeColor = Color.DimGray;
                    slider.Enabled = false;
                    value.ForeColor = Color.DimGray;
                    if (box != null) DisableCheckBox(box);
                }
            }
        }

        // for controls without slider (on/off) - and some with auto checkbox
        private void SetPropertyControls2(WebcamProperty prop, CheckBox box, Label text, CheckBox autoBox)
        {
            if (!prop.Supported)
            {
                if (!_controlsSet) // indicates first time set
                {
                    DisableCheckBox(box);
                    text.ForeColor = Color.DimGray;
                    if (autoBox != null) DisableCheckBox(autoBox);
                }
            }
            else
            {
                _ignoreCheckBox = true;
                box.Checked = (prop.Value != prop.Minimum);
                if (autoBox != null)
                {
                    if (!prop.AutoSupport)
                    {
                        if (!_controlsSet) DisableCheckBox(autoBox);
                    }
                    else
                    {
                        autoBox.Checked = prop.AutoEnabled;
                    }
                }
                _ignoreCheckBox = false;
            }
        }

        private void DisableCheckBox(CheckBox box)
        {
            Panel panel = new Panel();
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.BackColor = Color.DimGray;
            panel.Bounds = box.Bounds;
            panel.Top += 1;
            panel.Width -= 3; panel.Height -= 3;
            box.Visible = false;
            Controls.Add(panel);
        }

        // get properties and set their controls on the dialog
        private void GetProperties()
        {
            if (_getPropertiesBusy) return;
            _getPropertiesBusy = true;

            _timerSkip = true;

            SetPropertyControls(_basePlayer.Webcam.Brightness, brightnessLabel, brightnessSlider, brightnessValue, brightnessBox);
            SetPropertyControls(_basePlayer.Webcam.Contrast, contrastLabel, contrastSlider, contrastValue, contrastBox);
            SetPropertyControls(_basePlayer.Webcam.Hue, hueLabel, hueSlider, hueValue, hueBox);
            SetPropertyControls(_basePlayer.Webcam.Saturation, saturationLabel, saturationSlider, saturationValue, saturationBox);

            SetPropertyControls(_basePlayer.Webcam.Sharpness, sharpnessLabel, sharpnessSlider, sharpnessValue, sharpnessBox);
            SetPropertyControls(_basePlayer.Webcam.Gamma, gammaLabel, gammaSlider, gammaValue, gammaBox);
            SetPropertyControlsStep(_basePlayer.Webcam.WhiteBalance, whiteBalanceLabel, whiteBalanceSlider, whiteBalanceValue, whiteBalanceBox);
            SetPropertyControls(_basePlayer.Webcam.Gain, gainLabel, gainSlider, gainValue, gainBox);

            SetPropertyControls(_basePlayer.Webcam.Zoom, zoomLabel, zoomSlider, zoomValue, zoomBox);
            SetPropertyControls(_basePlayer.Webcam.Focus, focusLabel, focusSlider, focusValue, focusBox);
            SetPropertyControls(_basePlayer.Webcam.Exposure, exposureLabel, exposureSlider, exposureValue, exposureBox);
            SetPropertyControls(_basePlayer.Webcam.Iris, irisLabel, irisSlider, irisValue, irisBox);

            SetPropertyControls(_basePlayer.Webcam.Pan, panLabel, panSlider, panValue, panBox);
            SetPropertyControls(_basePlayer.Webcam.Tilt, tiltLabel, tiltSlider, tiltValue, tiltBox);
            SetPropertyControls(_basePlayer.Webcam.Roll, rollLabel, rollSlider, rollValue, rollBox);

            SetPropertyControls2(_basePlayer.Webcam.Flash, flashBox, flashLabel, autoFlashBox);
            SetPropertyControls2(_basePlayer.Webcam.BacklightCompensation, backlightBox, backlightLabel, autoBacklightBox);
            SetPropertyControls2(_basePlayer.Webcam.ColorEnable, colorEnableBox, colorEnableLabel, null);

            SetPropertyControls2(_basePlayer.Webcam.PowerLineFrequency, powerLineBox, powerLineLabel, null);
            if (!_ignoreCheckBox)
            {
                _ignoreCheckBox = true;
                WebcamProperty prop = _basePlayer.Webcam.PowerLineFrequency;
                if (_controlsSet && powerLineBox.Visible)
                {
                    if (prop.Value == 0)
                    {
                        if (powerLineBox.Checked) powerLineBox.Checked = false;
                        if (hz50Box.Checked) hz50Box.Checked = false;
                        if (hz60Box.Checked) hz60Box.Checked = false;
                    }
                    else
                    {
                        if (!powerLineBox.Checked) powerLineBox.Checked = true;
                        if (prop.Value == 1)
                        {
                            if (!hz50Box.Checked)
                            {
                                hz50Box.Checked = true;
                                hz60Box.Checked = false;
                            }
                        }
                        else if (prop.Value == 2)
                        {
                            if (!hz60Box.Checked)
                            {
                                hz50Box.Checked = false;
                                hz60Box.Checked = true;
                            }
                        }
                    }
                }
                else if (!_controlsSet && prop.Value != 0)
                {
                    if (prop.Value == 1) hz50Box.Checked = true;
                    else hz60Box.Checked = true;
                }
                _ignoreCheckBox = false;
            }

            _controlsSet = true;
            _getPropertiesBusy = false;
        }

        private void ResetProperties()
        {
            OKButton.Focus();

            _basePlayer.Webcam.ResetProperty(_basePlayer.Webcam.Brightness);
            _basePlayer.Webcam.ResetProperty(_basePlayer.Webcam.Contrast);
            _basePlayer.Webcam.ResetProperty(_basePlayer.Webcam.Hue);
            _basePlayer.Webcam.ResetProperty(_basePlayer.Webcam.Saturation);

            _basePlayer.Webcam.ResetProperty(_basePlayer.Webcam.Sharpness);
            _basePlayer.Webcam.ResetProperty(_basePlayer.Webcam.Gamma);
            _basePlayer.Webcam.ResetProperty(_basePlayer.Webcam.WhiteBalance);
            _basePlayer.Webcam.ResetProperty(_basePlayer.Webcam.Gain);

            _basePlayer.Webcam.ResetProperty(_basePlayer.Webcam.Zoom);
            _basePlayer.Webcam.ResetProperty(_basePlayer.Webcam.Focus);
            _basePlayer.Webcam.ResetProperty(_basePlayer.Webcam.Exposure);
            _basePlayer.Webcam.ResetProperty(_basePlayer.Webcam.Iris);

            _basePlayer.Webcam.ResetProperty(_basePlayer.Webcam.Pan);
            _basePlayer.Webcam.ResetProperty(_basePlayer.Webcam.Tilt);
            _basePlayer.Webcam.ResetProperty(_basePlayer.Webcam.Roll);

            _basePlayer.Webcam.ResetProperty(_basePlayer.Webcam.Flash);
            _basePlayer.Webcam.ResetProperty(_basePlayer.Webcam.BacklightCompensation);
            _basePlayer.Webcam.ResetProperty(_basePlayer.Webcam.ColorEnable);

            _basePlayer.Webcam.ResetProperty(_basePlayer.Webcam.PowerLineFrequency);
        }

        #endregion


        // ******************************** Drag Form

        #region Drag Form

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        private void DragForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Size savedSize = Size;

                _timerSkip = true;

                Cursor = Cursors.SizeAll;
                ((Control)sender).Capture = false;
                Message msg = Message.Create(Handle, WM_NCLBUTTONDOWN, (IntPtr)HT_CAPTION, IntPtr.Zero);
                base.WndProc(ref msg);

                Size = savedSize;

                Cursor = Cursors.Default;
            }
        }

        #endregion
    }
}
