#region Usings

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms;

#endregion

namespace AVPlayerExample
{
    public partial class MainWindow
    {
        // Automatically hide (after not having moved for a few seconds) and unhide (when moved/clicked) the mouse cursor when playing media.
        // A MessageFilter is used to detect mouse events.

        // For use with AVPlayerExample - for (general) use with other apps this code has to be changed/extended a little bit
        // - can also be easily changed to work with player displays instead of full forms

        #region Mouse Hide Fields

        private Timer           _mouseHideTimer;
        private DateTime        _mouseHideMoved;
        private Point           _mouseHideOldPosition;
        private bool            _mouseHideActive;
        private int             _mouseHideActiveCount;
        private bool            _mouseHideDisabled;
        private int             _mouseHideDisabledCount;
        private bool            _mouseHideHidden;
        private MouseHideFilter _mouseHideFilter;
        private List<Form>      _registeredForms;

        #endregion

        // *********

        #region Register Forms - Subscribe and unsubscribe Forms

        internal void RegisterMouseHideForm(Form form)
        {
            if (_registeredForms == null) _registeredForms = new List<Form>(8);
            if (!_registeredForms.Contains(form)) _registeredForms.Add(form);
        }

        internal void UnregisterMouseHideForm(Form form)
        {
            if (_registeredForms != null) _registeredForms.Remove(form);
        }

        #endregion

        // *********

        #region Mouse Hide activating and de-activating

        // It's assumed that there's at least 1 registered form - TODO suspend start if no registered forms
        internal void MouseHideStart()
        {
            if (Prefs.AutoHideCursor && !_mouseHideActive)
            {
                if (_mouseHideTimer == null)
                {
                    _mouseHideMoved = new DateTime();

                    _mouseHideTimer = new Timer();
                    _mouseHideTimer.Interval = Prefs.AutoHideCursorSeconds * 1000;
                    _mouseHideTimer.Tick += MouseHideTimer_Tick;

                    _mouseHideFilter = new MouseHideFilter();
                    _mouseHideFilter.Client = this;
                }

                _mouseHideMoved = DateTime.Now;
                _mouseHideTimer.Start();
                Application.AddMessageFilter(_mouseHideFilter);

                _mouseHideActiveCount++;
                _mouseHideActive = true;
            }
        }

        internal void MouseHideStop(bool dispose)
        {
            if ((--_mouseHideActiveCount <= 0 || dispose) && _mouseHideActive)
            {
                _mouseHideTimer.Stop();
                Application.RemoveMessageFilter(_mouseHideFilter);
                _mouseHideActive = false;

                if (_mouseHideHidden)
                {
                    Cursor.Show();
                    _mouseHideHidden = false;
                }
                _mouseHideActiveCount = 0;
            }

            //dispose = true is called from Dispose() (when quiting application) of MainWindow
            if (dispose && _mouseHideTimer != null)
            {
                _mouseHideTimer.Dispose();
                _mouseHideTimer = null;
                _mouseHideFilter.Client = null;
                _mouseHideFilter = null;
                _registeredForms.Clear();
                _registeredForms = null;
            }
        }

        #endregion

        #region Mouse Hide timer (hide) and mouse move and action (show) eventhandlers

        // strange: bottom scrolling text of message overlay influences ActiveForm value or mouse event?
        private void MouseHideTimer_Tick(object sender, EventArgs e)
        {
            if (_mouseHideDisabled) return;

            if (!_mouseHideHidden && Form.ActiveForm != null)
            {
                if ((DateTime.Now - _mouseHideMoved).TotalSeconds >= Prefs.AutoHideCursorSeconds)
                {
                    if (_registeredForms.Contains(Form.ActiveForm))
                    {
                        _mouseHideTimer.Stop();
                        _mouseHideOldPosition = Cursor.Position;
                        Cursor.Hide();
                        HideSliderPreviewByTimer();
                        _mouseHideHidden = true;
                    }
                }
            }
        }

        private void MouseHideMove()
        {
            _mouseHideMoved = DateTime.Now;
            if (_mouseHideHidden)
            {
                Point _mouseHideNewPosition = Cursor.Position;
                if (Math.Abs(_mouseHideNewPosition.X - _mouseHideOldPosition.X) >= 2 || Math.Abs(_mouseHideNewPosition.Y - _mouseHideOldPosition.Y) >= 2)
                {
                    Cursor.Show();
                    _mouseHideHidden = false;
                    _mouseHideTimer.Start();
                }
                else _mouseHideOldPosition = _mouseHideNewPosition;
            }
        }

        private void MouseHideAction()
        {
            _mouseHideMoved = DateTime.Now;
            if (_mouseHideHidden)
            {
                Cursor.Show();
                _mouseHideHidden = false;
                _mouseHideTimer.Start();
            }
        }

        #endregion

        // *********

        #region Temporarily disable MouseHide by contextmenus

        // Temporarily disable hiding of the mouse cursor (should be done for all pop-up menus)
        private void ContextMenu_Opening(object sender, CancelEventArgs e)
        {
            _mouseHideDisabled = true;
            _mouseHideDisabledCount++;
        }

        private void ContextMenu_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (--_mouseHideDisabledCount <= 0)
            {
                _mouseHideDisabled = false;
                _mouseHideDisabledCount = 0;
            }
        }

        #endregion

        // *********

        #region Mouse Hide MessageFilter

        public class MouseHideFilter : IMessageFilter
        {
            internal MainWindow Client;

            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == 0x0200) Client.MouseHideMove(); // WM_MOUSEMOVE
                else if (m.Msg > 0x0200 && m.Msg <= 0x020A) Client.MouseHideAction();
                return false;
            }
        }

        #endregion
    }
}
