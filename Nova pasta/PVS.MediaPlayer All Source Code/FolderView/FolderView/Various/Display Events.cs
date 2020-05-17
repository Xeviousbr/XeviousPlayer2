#region Usings

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace FolderView
{
    // A class (+ 2 small supporting classes) that provides mouse events on MCI video display windows
    // ... under construction

    [Flags]
    public enum DisplayEventFlags
    {
        MouseMove = 1,

        LeftButtonDown = 2,
        LeftButtonUp = 4,
        LeftButtonDoubleClick = 8,

        MiddleButtonDown = 16,
        MiddleButtonUp = 32,
        MiddleButtonDoubleClick = 64,

        RightButtonDown = 128,
        RightButtonUp = 256,
        RightButtonDoubleClick = 512,

        MouseWheel = 1024
    }

    public class DisplayEventArgs : EventArgs
    {
        internal MouseButtons   _button;
        internal int            _clicks;
        internal Point          _location;
        //internal int            _delta;

        public MouseButtons Button
        {
            get { return _button; }
        }

        public int Clicks
        {
            get { return _clicks; }
        }

        public Point Location
        {
            get { return _location; }
        }

        public int X
        {
            get { return _location.X; }
        }

        public int Y
        {
            get { return _location.Y; }
        }

        //public int Delta
        //{
        //    get { return _delta; }
        //}
    }

    static class DisplayHandler
    {
        // ******************************** Fields

        #region Fields

        private class Client
        {
            internal Control                        Display;
            internal Form                           Window;
            internal DisplayEventFlags              MouseEvent;
            internal EventHandler<DisplayEventArgs> CallBack;

            public Client(Control display, Form window, DisplayEventFlags displayEvent, EventHandler<DisplayEventArgs> callBack)
            {
                Display     = display;
                Window      = window;
                MouseEvent  = displayEvent;
                CallBack    = callBack;
            }
        }

        private class MessageFilter : IMessageFilter
        {
            #region Fields

            private const int WM_MOUSEMOVE      = 0x0200;
            private const int WM_LBUTTONDOWN    = 0x0201;
            private const int WM_LBUTTONUP      = 0x0202;
            private const int WM_LBUTTONDBLCLK  = 0x0203;
            private const int WM_RBUTTONDOWN    = 0x0204;
            private const int WM_RBUTTONUP      = 0x0205;
            private const int WM_RBUTTONDBLCLK  = 0x0206;
            private const int WM_MBUTTONDOWN    = 0x0207;
            private const int WM_MBUTTONUP      = 0x0208;
            private const int WM_MBUTTONDBLCLK  = 0x0209;
            private const int WM_MOUSEWHEEL     = 0x020A;

            internal List<Client>       _clients;
            private Point               _mousePosition;
            private DisplayEventArgs    _displayEventArgs = new DisplayEventArgs();
            private bool                _busy;

            #endregion

            public bool PreFilterMessage(ref Message m)
            {
                if (!_busy)
                {
                    _busy = true;
                    if (_clients.Count > 0 && Form.ActiveForm != null) // application in foreground
                    {
                        _mousePosition = Control.MousePosition;
                        switch (m.Msg)
                        {
                            case (WM_MOUSEMOVE):
                                DoCallBacks(DisplayEventFlags.MouseMove);
                                _displayEventArgs._button = MouseButtons.None;
                                _displayEventArgs._clicks = 0;
                                break;

                            case (WM_LBUTTONDOWN):
                                _displayEventArgs._button = MouseButtons.Left;
                                _displayEventArgs._clicks = 1;
                                DoCallBacks(DisplayEventFlags.LeftButtonDown);
                                break;
                            case (WM_LBUTTONUP):
                                _displayEventArgs._button = MouseButtons.Left;
                                _displayEventArgs._clicks = 1;
                                DoCallBacks(DisplayEventFlags.LeftButtonUp);
                                break;
                            case (WM_LBUTTONDBLCLK):
                                _displayEventArgs._button = MouseButtons.Left;
                                _displayEventArgs._clicks = 2;
                                DoCallBacks(DisplayEventFlags.LeftButtonDoubleClick);
                                break;

                            case (WM_MBUTTONDOWN):
                                DoCallBacks(DisplayEventFlags.MiddleButtonDown);
                                break;
                            case (WM_MBUTTONUP):
                                DoCallBacks(DisplayEventFlags.MiddleButtonUp);
                                break;
                            case (WM_MBUTTONDBLCLK):
                                DoCallBacks(DisplayEventFlags.MiddleButtonDoubleClick);
                                break;

                            case (WM_RBUTTONDOWN):
                                _displayEventArgs._button = MouseButtons.Right;
                                _displayEventArgs._clicks = 1;
                                DoCallBacks(DisplayEventFlags.RightButtonDown);
                                break;
                            case (WM_RBUTTONUP):
                                _displayEventArgs._button = MouseButtons.Right;
                                _displayEventArgs._clicks = 1;
                                DoCallBacks(DisplayEventFlags.RightButtonUp);
                                break;
                            case (WM_RBUTTONDBLCLK):
                                _displayEventArgs._button = MouseButtons.Right;
                                _displayEventArgs._clicks = 2;
                                DoCallBacks(DisplayEventFlags.RightButtonDoubleClick);
                                break;

                            case (WM_MOUSEWHEEL):
                                DoCallBacks(DisplayEventFlags.MouseWheel);
                                break;
                        }
                    }
                    _busy = false;
                }
                return false;
            }

            private void DoCallBacks(DisplayEventFlags mouseEvent)
            {
                Form activeForm = Form.ActiveForm; // already checked (above) app is in foreground

                for (int i = 0; i < _clients.Count; i++)
                {
                    if (_clients[i].Window == activeForm 
                        && (_clients[i].MouseEvent & mouseEvent) != 0
                        && _clients[i].Display.ClientRectangle.Contains(_clients[i].Display.PointToClient(_mousePosition)))
                        {
                            _displayEventArgs._location = _clients[i].Display.PointToClient(_mousePosition);
                            //_displayEventArgs._delta = 0; // Todo
                            _clients[i].CallBack(_clients[i].Display, _displayEventArgs);
                            break;
                        }
                }
            }
        }

        private static List<Client>     _clients;
        private static MessageFilter    _messageFilter;
        private static bool             _hasMessageFilter;

        #endregion

        // ******************************** Main

        static DisplayHandler()
        {
            _clients                = new List<Client>();
            _messageFilter          = new MessageFilter();
            _messageFilter._clients = _clients;
        }

        // ******************************** Subscribe / Unsubsribe / UnsubscribeAll

        public static void Subscribe(Control display, DisplayEventFlags mouseEvent, EventHandler<DisplayEventArgs> callBack)
        {
            if (display != null)
            {
                bool found = false;

                for (int i = 0; i < _clients.Count; i++)
                {
                    if (_clients[i].Display == display && _clients[i].MouseEvent == mouseEvent)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Client newClient = new Client(display, display.FindForm(), mouseEvent, callBack);
                    _clients.Add(newClient);

                    if (!_hasMessageFilter)
                    {
                        Application.AddMessageFilter(_messageFilter);
                        _hasMessageFilter = true;
                    }
                }
            }
        }

        // just for this app - the displays (panels) aren't yet put on a form when these methods are called, so we need a form reference
        public static void Subscribe(Control display, Form form, DisplayEventFlags mouseEvent, EventHandler<DisplayEventArgs> callBack)
        {
            if (display != null)
            {
                bool found = false;

                for (int i = 0; i < _clients.Count; i++)
                {
                    if (_clients[i].Display == display && _clients[i].MouseEvent == mouseEvent)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Client newClient = new Client(display, form, mouseEvent, callBack);
                    _clients.Add(newClient);

                    if (!_hasMessageFilter)
                    {
                        Application.AddMessageFilter(_messageFilter);
                        _hasMessageFilter = true;
                    }
                }
            }
        }

        public static void Unsubscribe(Control display, DisplayEventFlags mouseEvent)
        {
            if (display != null)
            {
                for (int i = 0; i < _clients.Count; i++)
                {
                    if (_clients[i].Display == display && _clients[i].MouseEvent == mouseEvent)
                    {
                        _clients.RemoveAt(i);
                        break;
                    }
                }

                if (_clients.Count == 0 && _hasMessageFilter)
                {
                    Application.RemoveMessageFilter(_messageFilter);
                    _hasMessageFilter = false;
                }
            }
        }

        public static void UnsubscribeAll()
        {
            _clients.Clear();
            Application.RemoveMessageFilter(_messageFilter);
            _hasMessageFilter = false;
        }
    }

}
