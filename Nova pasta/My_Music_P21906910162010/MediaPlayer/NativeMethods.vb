Imports System
Imports System.Runtime.InteropServices
Imports System.Text

Friend NotInheritable Class NativeMethods

    '<DllImport("winmm.dll")> _
    'Friend Shared Function mciSendString(ByVal strCommand As String, ByVal strReturn As StringBuilder, ByVal iReturnLength As Integer, ByVal hwndCallback As IntPtr) As Integer
    'End Function

    Private Sub New()
        ' for the compiler
    End Sub

    ''' <summary>
    ''' The mciSendString function sends a command string to an MCI device. The device that the command is sent to is specified in the command string.
    ''' </summary>
    ''' <param name="lpstrCommand">Address of a null-terminated string that specifies an MCI command string.</param>
    ''' <param name="lpstrReturnString">Address of a buffer that receives return information. If no return information is needed, this parameter can be null (Nothing in VB.NET).</param>
    ''' <param name="uReturnLength">Size, in characters, of the return buffer specified by the lpszReturnString parameter.</param>
    ''' <param name="hwndCallback">Handle of a callback window if the notify flag was specified in the command string.</param>
    ''' <returns>Returns zero if successful or an error otherwise. The low-order word of the returned doubleword value contains the error return value. If the error is device-specific, the high-order word of the return value is the driver identifier; otherwise, the high-order word is zero.<br>To retrieve a text description of mciSendString return values, pass the return value to the mciGetErrorString function.</br></returns>
    Friend Declare Ansi Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As StringBuilder, ByVal uReturnLength As Integer, ByVal hwndCallback As IntPtr) As Integer

    ''' <summary>
    ''' The mciGetErrorString function retrieves a string that describes the specified MCI error code.
    ''' </summary>
    ''' <param name="dwError">Error code returned by the mciSendCommand or mciSendString function.</param>
    ''' <param name="lpstrBuffer">Address of a buffer that receives a null-terminated string describing the specified error.</param>
    ''' <param name="uLength">Length of the buffer, in characters, pointed to by the lpszErrorText parameter.</param>
    ''' <returns>Returns TRUE if successful or FALSE if the error code is not known.</returns>
    Friend Declare Ansi Function mciGetErrorString Lib "winmm.dll" Alias "mciGetErrorStringA" (ByVal dwError As Integer, ByVal lpstrBuffer As StringBuilder, ByVal uLength As Integer) As Integer

End Class
