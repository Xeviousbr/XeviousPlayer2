#region Usings

using System;
using System.Runtime.InteropServices;
using System.Security;

#endregion

namespace FolderView
{
    [SuppressUnmanagedCodeSecurity]
    internal static class SafeNativeMethods
    {
        #region SendMessage

        internal const int TBM_GETTHUMBRECT = 0x419;
        //internal const int TBM_GETCHANNELRECT = 0x41A;

        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT { public int left, top, right, bottom; }

        [DllImport("user32.dll")]
        internal static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, ref RECT lp);

        #endregion

        #region ShellExecute

        // ******************************** Get file properties dialog - Thanks www.pinvoke.net

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        static extern internal bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

        [StructLayout(LayoutKind.Sequential)]
        internal struct SHELLEXECUTEINFO
        {
            public int cbSize;
            public uint fMask;
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpVerb;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpFile;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpParameters;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpDirectory;
            public int nShow;
            public IntPtr hInstApp;
            public IntPtr lpIDList;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpClass;
            public IntPtr hkeyClass;
            public uint dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }

        internal const int SW_SHOW = 5;
        internal const uint SEE_MASK_INVOKEIDLIST = 12;

        #endregion

        #region SetForegroundWindow

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);

        #endregion

        #region GetForegroundWindow

        [DllImport("user32.dll")]
        internal static extern IntPtr GetForegroundWindow();

        #endregion

        #region Custom TreeView Sort

        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        internal static extern int StrCmpLogicalW(string x, string y);

        #endregion

        #region Show/Hide/Check Treeview ScrollBars

        internal const int SB_HORZ = 0;
        internal const int SB_VERT = 1;
        internal const int SB_CTL = 2;
        internal const int SB_BOTH = 3;

        [DllImport("user32.dll")]
        internal static extern int ShowScrollBar(IntPtr hWnd, int wBar, int bShow);

        internal const int GWL_STYLE = -16;
        internal const int WS_HSCROLL = 0x00100000;
        internal const int WS_VSCROLL = 0x00200000;

        [DllImport("user32.dll", ExactSpelling = false, CharSet = CharSet.Auto)]
        internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        #endregion
    }
}
