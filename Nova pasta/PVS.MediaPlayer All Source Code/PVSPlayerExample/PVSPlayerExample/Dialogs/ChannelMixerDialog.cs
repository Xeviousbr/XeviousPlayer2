#region Usings

using PVS.MediaPlayer;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    public partial class AudioVolumesDialog : Form
    {

        #region Fields

        private const int   CHANNELS_COUNT      = 16; // Player setting
        private const int   METERS_COUNT        = 8;

        private Color       TEXT_FORECOLOR      = Color.FromArgb(179, 173, 146);

        private MainWindow  _baseForm;
        private Player      _basePlayer;

        private float[]     _savedVolumes;
        private float[]     _currentVolumes;
        private float[]     _setVolumes;
        private bool[]      _redDials;

        private int         _levelMeterWidth;
        private int         _levelMeterHeight;
        private float[]     _peakLevels;
        private bool        _levelMeterBusy;

        private HatchBrush  _meterBrush;
        private HatchStyle  _meterBrushHatchStyle = HatchStyle.DarkHorizontal;

        private bool        _skipAudioEvents;
        private bool        _setValuesOnly;
        private bool        _muteLock;

        private double      _oldOpacity;
        private bool        _disposed;

        #endregion


        #region Main

        public AudioVolumesDialog(MainWindow baseForm, Player basePlayer)
        {
            InitializeComponent();

            Icon                = Properties.Resources.Media_Normal;

            _baseForm           = baseForm;
            _basePlayer         = basePlayer;

            _savedVolumes       = _basePlayer.Audio.ChannelVolumes;
            _currentVolumes     = _basePlayer.Audio.ChannelVolumes;
            _setVolumes         = new float[METERS_COUNT];
            _redDials           = new bool[METERS_COUNT];

            _peakLevels         = new float[CHANNELS_COUNT];
            _meterBrush         = new HatchBrush(_meterBrushHatchStyle, Color.FromArgb(179, 173, 146));

            _levelMeterWidth    = peakMeter1.ClientRectangle.Width;
            _levelMeterHeight   = peakMeter1.ClientRectangle.Height;

            // can't set this in the editor anymore (?)
            channelLight1.ForeColor = Color.Red;
            channelLight2.ForeColor = Color.Red;
            channelLight3.ForeColor = Color.Red;
            channelLight4.ForeColor = Color.Red;
            channelLight5.ForeColor = Color.Red;
            channelLight6.ForeColor = Color.Red;
            channelLight7.ForeColor = Color.Red;
            channelLight8.ForeColor = Color.Red;

            _oldOpacity = Opacity;
            Opacity     = 0;
        }

        private void AudioVolumesDialog_Shown(object sender, EventArgs e)
        {
            _basePlayer.Events.MediaAudioVolumeChanged  += Events_MediaAudioVolumeChanged;
            _basePlayer.Events.MediaAudioBalanceChanged += Events_MediaAudioVolumeChanged;
            _basePlayer.Events.MediaAudioMuteChanged    += Events_MediaAudioMuteChanged;
            _basePlayer.Events.MediaPeakLevelChanged    += Events_MediaPeakLevelChanged;
            _basePlayer.Events.MediaAudioDeviceChanged  += Events_MediaAudioDeviceChanged;

            dial1.ValueChanged += Dial1_ValueChanged;
            dial2.ValueChanged += Dial2_ValueChanged;
            dial3.ValueChanged += Dial3_ValueChanged;
            dial4.ValueChanged += Dial4_ValueChanged;
            dial5.ValueChanged += Dial5_ValueChanged;
            dial6.ValueChanged += Dial6_ValueChanged;
            dial7.ValueChanged += Dial7_ValueChanged;
            dial8.ValueChanged += Dial8_ValueChanged;

            _setValuesOnly = true;
            SetVolumeDials();
            SetChannelButtons();
            if (_basePlayer.Audio.Mute) SetVolumeMute();
            _setValuesOnly = false;

            okButton.Focus();

            Application.DoEvents();
            System.Threading.Thread.Sleep(75);

            Opacity = _oldOpacity;
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    Pen pen         = new Pen(Color.FromArgb(109, 103, 76), 1);
        //    Rectangle rect  = DisplayRectangle;
        //    rect.Width      -= 1;
        //    rect.Height     -= 1;
        //    e.Graphics.DrawRectangle(pen, rect);
        //    pen.Dispose();
        //}

        private void PvsLogo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.PVSLogoOutline, 4, 0);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AudioVolumesDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            _basePlayer.Events.MediaAudioVolumeChanged  -= Events_MediaAudioVolumeChanged;
            _basePlayer.Events.MediaAudioBalanceChanged -= Events_MediaAudioVolumeChanged;
            _basePlayer.Events.MediaAudioMuteChanged    -= Events_MediaAudioMuteChanged;
            _basePlayer.Events.MediaPeakLevelChanged    -= Events_MediaPeakLevelChanged;
            _basePlayer.Events.MediaAudioDeviceChanged  -= Events_MediaAudioDeviceChanged;

            if (DialogResult != DialogResult.OK)
            {
                _basePlayer.Audio.ChannelVolumes = _savedVolumes;
            }

            _baseForm._audioVolumesDialog = null;
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                if (disposing)
                {
                    _baseForm   = null;
                    _basePlayer = null;

                    if (_meterBrush != null) _meterBrush.Dispose();

                    if (components != null) components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion


        #region Player Events

        private void Events_MediaAudioVolumeChanged(object sender, EventArgs e)
        {
            if (!_skipAudioEvents)
            {
                _setValuesOnly = true;
                SetVolumeMute();
                SetVolumeDials();
                _setValuesOnly = false;
            }
        }

        private void Events_MediaAudioMuteChanged(object sender, EventArgs e)
        {
            SetVolumeMute();
            SetVolumes();
        }

        private void Events_MediaPeakLevelChanged(object sender, PeakLevelEventArgs e)
        {
            if (!_levelMeterBusy)
            {
                _levelMeterBusy = true;

                int count = e.ChannelCount;

                int i = 0;
                for (; i < count; i++)
                {
                    if (e.ChannelsValues[i] == -1) _peakLevels[i] = 0;
                    else _peakLevels[i] = e.ChannelsValues[i];
                }
                //for (; i < 16; i++)
                //{
                //    _peakLevels[i] = 0;
                //}

                // draw meters - using doublebuffer
                if (count > 0)
                {
                    peakMeter1.Invalidate();
                    peakMeter2.Invalidate();
                    if (count > 2)
                    {
                        peakMeterl3.Invalidate();
                        peakMeter4.Invalidate();
                        peakMeter5.Invalidate();
                        if (count > 5)
                        {
                            peakMeter6.Invalidate();
                            peakMeter7.Invalidate();
                            peakMeter8.Invalidate();
                        }
                    }
                }

                _levelMeterBusy = false;
            }
        }

        private void Events_MediaAudioDeviceChanged(object sender, EventArgs e)
        {
            SetChannelButtons();
        }

        #endregion


        #region Set Channel Volumes

        private void SetVolumes()
        {
            if (!_setValuesOnly)
            {
                _setVolumes[0] = channelLight1.LightOn ? 0 : _currentVolumes[0];
                _setVolumes[1] = channelLight2.LightOn ? 0 : _currentVolumes[1];
                _setVolumes[2] = channelLight3.LightOn ? 0 : _currentVolumes[2];
                _setVolumes[3] = channelLight4.LightOn ? 0 : _currentVolumes[3];
                _setVolumes[4] = channelLight5.LightOn ? 0 : _currentVolumes[4];
                _setVolumes[5] = channelLight6.LightOn ? 0 : _currentVolumes[5];
                _setVolumes[6] = channelLight7.LightOn ? 0 : _currentVolumes[6];
                _setVolumes[7] = channelLight8.LightOn ? 0 : _currentVolumes[7];

                _skipAudioEvents = true;
                _basePlayer.Audio.ChannelVolumes = _setVolumes;
                _skipAudioEvents = false;
            }
        }

        #endregion

        #region Set Channel Mute

        // player mute event handler
        private void SetVolumeMute()
        {
            bool muted               = _basePlayer.Audio.Mute;
            Color textColor          = muted ? Color.Red : TEXT_FORECOLOR;

            channelLight1.LightOn    = muted;
            channelButton1.ForeColor = textColor;
            muteButton1.Enabled      = !muted;

            channelLight2.LightOn    = muted;
            channelButton2.ForeColor = textColor;
            muteButton2.Enabled      = !muted;

            channelLight3.LightOn    = muted;
            channelButton3.ForeColor = textColor;
            muteButton3.Enabled      = !muted;

            channelLight4.LightOn    = muted;
            channelButton4.ForeColor = textColor;
            muteButton4.Enabled      = !muted;

            channelLight5.LightOn    = muted;
            channelButton5.ForeColor = textColor;
            muteButton5.Enabled      = !muted;

            channelLight6.LightOn    = muted;
            channelButton6.ForeColor = textColor;
            muteButton6.Enabled      = !muted;

            channelLight7.LightOn    = muted;
            channelButton7.ForeColor = textColor;
            muteButton7.Enabled      = !muted;

            channelLight8.LightOn    = muted;
            channelButton8.ForeColor = textColor;
            muteButton8.Enabled      = !muted;

            _muteLock = muted;
        }

        #endregion

        #region Volume Dials

        private void SetVolumeDials()
        {
            float[] volumes = _basePlayer.Audio.ChannelVolumes;

            dial1.Value = (int)(volumes[0] * 1000);
            label1.Text = volumes[0].ToString("0.00");

            dial2.Value = (int)(volumes[1] * 1000);
            label2.Text = volumes[1].ToString("0.00");

            dial3.Value = (int)(volumes[2] * 1000);
            label3.Text = volumes[2].ToString("0.00");

            dial4.Value = (int)(volumes[3] * 1000);
            label4.Text = volumes[3].ToString("0.00");

            dial5.Value = (int)(volumes[4] * 1000);
            label5.Text = volumes[4].ToString("0.00");

            dial6.Value = (int)(volumes[5] * 1000);
            label6.Text = volumes[5].ToString("0.00");

            dial7.Value = (int)(volumes[6] * 1000);
            label7.Text = volumes[6].ToString("0.00");

            dial8.Value = (int)(volumes[7] * 1000);
            label8.Text = volumes[7].ToString("0.00");
        }

        private void Dial1_ValueChanged(object sender, Dial.ValueChangedEventArgs e)
        {
            SetDial(dial1, 0, label1, channelLight1);
        }

        private void Dial2_ValueChanged(object sender, Dial.ValueChangedEventArgs e)
        {
            SetDial(dial2, 1, label2, channelLight2);
        }

        private void Dial3_ValueChanged(object sender, Dial.ValueChangedEventArgs e)
        {
            SetDial(dial3, 2, label3, channelLight3);
        }

        private void Dial4_ValueChanged(object sender, Dial.ValueChangedEventArgs e)
        {
            SetDial(dial4, 3, label4, channelLight4);
        }

        private void Dial5_ValueChanged(object sender, Dial.ValueChangedEventArgs e)
        {
            SetDial(dial5, 4, label5, channelLight5);
        }

        private void Dial6_ValueChanged(object sender, Dial.ValueChangedEventArgs e)
        {
            SetDial(dial6, 5, label6, channelLight6);
        }

        private void Dial7_ValueChanged(object sender, Dial.ValueChangedEventArgs e)
        {
            SetDial(dial7, 6, label7, channelLight7);
        }

        private void Dial8_ValueChanged(object sender, Dial.ValueChangedEventArgs e)
        {
            SetDial(dial8, 7, label8, channelLight8);
        }

        private void SetDial(Dial dial, int index, Label label, LightPanel lightPanel)
        {
            _currentVolumes[index] = dial.Value * 0.001f;

            if (_currentVolumes[index] == 0)
            {
                if (!_redDials[index])
                {
                    dial.SwitchImage(true);
                    _redDials[index] = true;
                }
            }
            else
            {
                if (_redDials[index])
                {
                    dial.SwitchImage(false);
                    _redDials[index] = false;
                }
            }

            label.Text = _currentVolumes[index].ToString("0.00");
            if (!lightPanel.LightOn) SetVolumes();
        }

        #endregion

        #region Mute Buttons

        private void MuteButton1_Click(object sender, EventArgs e)
        {
            if (!_muteLock)
            {
                channelLight1.LightOn      = !channelLight1.LightOn;
                channelButton1.ForeColor = channelLight1.LightOn ? Color.Red : TEXT_FORECOLOR;
                SetVolumes();
            }
        }

        private void MuteButton2_Click(object sender, EventArgs e)
        {
            if (!_muteLock)
            {
                channelLight2.LightOn      = !channelLight2.LightOn;
                channelButton2.ForeColor = channelLight2.LightOn ? Color.Red : TEXT_FORECOLOR;
                SetVolumes();
            }
        }

        private void MuteButton3_Click(object sender, EventArgs e)
        {
            if (!_muteLock)
            {
                channelLight3.LightOn      = !channelLight3.LightOn;
                channelButton3.ForeColor = channelLight3.LightOn ? Color.Red : TEXT_FORECOLOR;
                SetVolumes();
            }
        }

        private void MuteButton4_Click(object sender, EventArgs e)
        {
            if (!_muteLock)
            {
                channelLight4.LightOn      = !channelLight4.LightOn;
                channelButton4.ForeColor = channelLight4.LightOn ? Color.Red : TEXT_FORECOLOR;
                SetVolumes();
            }
        }

        private void MuteButton5_Click(object sender, EventArgs e)
        {
            if (!_muteLock)
            {
                channelLight5.LightOn      = !channelLight5.LightOn;
                channelButton5.ForeColor = channelLight5.LightOn ? Color.Red : TEXT_FORECOLOR;
                SetVolumes();
            }
        }

        private void MuteButton6_Click(object sender, EventArgs e)
        {
            if (!_muteLock)
            {
                channelLight6.LightOn      = !channelLight6.LightOn;
                channelButton6.ForeColor = channelLight6.LightOn ? Color.Red : TEXT_FORECOLOR;
                SetVolumes();
            }
        }

        private void MuteButton7_Click(object sender, EventArgs e)
        {
            if (!_muteLock)
            {
                channelLight7.LightOn      = !channelLight7.LightOn;
                channelButton7.ForeColor = channelLight7.LightOn ? Color.Red : TEXT_FORECOLOR;
                SetVolumes();
            }
        }

        private void MuteButton8_Click(object sender, EventArgs e)
        {
            if (!_muteLock)
            {
                channelLight8.LightOn      = !channelLight8.LightOn;
                channelButton8.ForeColor = channelLight8.LightOn ? Color.Red : TEXT_FORECOLOR;
                SetVolumes();
            }
        }

        #endregion


        #region Update Channel Enabled Indicators

        private void SetChannelButtons()
        {
            int count = _basePlayer.Audio.DeviceChannelCount;

            channelButton1.Enabled  = count > 0;
            channelButton2.Enabled  = count > 1;
            channelButton3.Enabled  = count > 2;
            channelButton4.Enabled  = count > 3;
            channelButton5.Enabled  = count > 4;
            channelButton6.Enabled  = count > 5;
            channelButton7.Enabled  = count > 6;
            channelButton8.Enabled  = count > 7;
        }

        #endregion

        #region Update Peak Meters

        private void PeakMeter1_Paint(object sender, PaintEventArgs e)
        {
            if (_peakLevels[0] > 0)
            {
                float yPos = _levelMeterHeight - (_peakLevels[0] * _levelMeterHeight);
                e.Graphics.FillRectangle(_meterBrush, 0, yPos, _levelMeterWidth, _levelMeterHeight);
            }
        }

        private void PeakMeter2_Paint(object sender, PaintEventArgs e)
        {
            if (_peakLevels[1] > 0)
            {
                float yPos = _levelMeterHeight - (_peakLevels[1] * _levelMeterHeight);
                e.Graphics.FillRectangle(_meterBrush, 0, yPos, _levelMeterWidth, _levelMeterHeight);
            }
        }

        private void PeakMeter3_Paint(object sender, PaintEventArgs e)
        {
            if (_peakLevels[2] > 0)
            {
                float yPos = _levelMeterHeight - (_peakLevels[2] * _levelMeterHeight);
                e.Graphics.FillRectangle(_meterBrush, 0, yPos, _levelMeterWidth, _levelMeterHeight);
            }
        }

        private void PeakMeter4_Paint(object sender, PaintEventArgs e)
        {
            if (_peakLevels[3] > 0)
            {
                float yPos = _levelMeterHeight - (_peakLevels[3] * _levelMeterHeight);
                e.Graphics.FillRectangle(_meterBrush, 0, yPos, _levelMeterWidth, _levelMeterHeight);
            }
        }

        private void PeakMeter5_Paint(object sender, PaintEventArgs e)
        {
            if (_peakLevels[4] > 0)
            {
                float yPos = _levelMeterHeight - (_peakLevels[4] * _levelMeterHeight);
                e.Graphics.FillRectangle(_meterBrush, 0, yPos, _levelMeterWidth, _levelMeterHeight);
            }
        }

        private void PeakMeter6_Paint(object sender, PaintEventArgs e)
        {
            if (_peakLevels[5] > 0)
            {
                float yPos = _levelMeterHeight - (_peakLevels[5] * _levelMeterHeight);
                e.Graphics.FillRectangle(_meterBrush, 0, yPos, _levelMeterWidth, _levelMeterHeight);
            }
        }

        private void PeakMeter7_Paint(object sender, PaintEventArgs e)
        {
            if (_peakLevels[6] > 0)
            {
                float yPos = _levelMeterHeight - (_peakLevels[6] * _levelMeterHeight);
                e.Graphics.FillRectangle(_meterBrush, 0, yPos, _levelMeterWidth, _levelMeterHeight);
            }
        }

        private void PeakMeter8_Paint(object sender, PaintEventArgs e)
        {
            if (_peakLevels[7] > 0)
            {
                float yPos = _levelMeterHeight - (_peakLevels[7] * _levelMeterHeight);
                e.Graphics.FillRectangle(_meterBrush, 0, yPos, _levelMeterWidth, _levelMeterHeight);
            }
        }

        #endregion


        #region Volume Menu

        private void MuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((Dial)volumeMenu.SourceControl).Value = 0;
        }

        private void LowVolumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((Dial)volumeMenu.SourceControl).Value = 250;
        }

        private void AverageVolumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((Dial)volumeMenu.SourceControl).Value = 500;
        }

        private void HighVolumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((Dial)volumeMenu.SourceControl).Value = 750;
        }

        private void MaximumVolumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((Dial)volumeMenu.SourceControl).Value = 1000;
        }

        #endregion
    }
}
