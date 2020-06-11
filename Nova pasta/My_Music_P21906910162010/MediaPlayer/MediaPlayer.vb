' 
' MediaPlayer class provides basic functionallity for playing any media files.
' 
' Aside from the various methods it implemants events which notify their subscribers for opening files, pausing, etc.
' This is done for boosting performance on your applications using this class, because instead of checking for info
' on the player status over a certain time period and loosing performance, you can subscribe for an event and
' handle it when it fires.
' 
' This class also doesn't throw exceptions. The error handling is done by an event, because the probable errors
' which may occur are not severe and the application just needs to be notified for these failures on the fly...
' Share your source and modify this code to your heart's content, just don't change this section.
' If you have questions, suggestions or just need to make your oppinion heard my email is krazymir@gmail.com
' 
' Krasimir kRAZY Kalinov 2006
'

Imports System
Imports System.Text
Imports System.Runtime.InteropServices


Public Class MediaPlayer
    Implements IDisposable

#Region " Private Members "

    Private _Command, _FileName, _Alias As String
    Private _Opened, _Playing, _Paused, _Loop, _MutedAll, _MutedLeft, _MutedRight As Boolean
    Private _VolumeRight, _VolumeLeft, _Volume, _VolumeTreble, _VolumeBass As Integer
    Private _Duration As Integer
    Private _Error As Integer
    Private _Disposed As Boolean

#End Region

#Region " Constructor "

    ''' <summary>
    ''' Creates a new instance of SoundPlayer.
    ''' Parameter allows creation of unique instance that allow multiple files to play at once.
    ''' </summary>
    ''' <param name="instance"></param>
    Public Sub New(ByVal instance As Integer)

        ' Set all volumes to 1/2.
        _VolumeRight = 500
        _VolumeLeft = 500
        _Volume = 500
        _VolumeTreble = 500
        _VolumeBass = 500

        ' Create alias from "MediaFile" & instance.ToString().
        ' This allows multiple files to play at once.
        If instance >= 0 And instance <= 100 Then
            _Alias = "MediaFile" & instance.ToString()
        Else
            _Alias = "MediaFile"
        End If

    End Sub

#End Region

#Region " Destructor "

    ''' <summary>
    ''' Dispose for this class.
    ''' </summary>
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    ''' <summary>
    ''' Called by public method to free both managed and native resources.
    ''' </summary>
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            ' Free managed resources.
        End If

        ' Free native resources.
        If NativeMethods.mciSendString("CLOSE " & _Alias, Nothing, 0, IntPtr.Zero) <> 0 Then
            _Disposed = False
        End If

    End Sub

    ''' <summary>
    ''' Gets whether the object has been disposed or not.
    ''' </summary>
    ''' <value>True if the object has been disposed, false otherwise.</value>
    Public ReadOnly Property Disposed() As Boolean
        Get
            Return _Disposed
        End Get
    End Property

    ''' <summary>
    ''' Destructs the MediaFile object by calling the Dispose method.
    ''' </summary>
    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub

#End Region

#Region " Volume Properties "

    ''' <summary>
    ''' Gets mute status for both channels. Toggles mute on/off for both channels.
    ''' </summary>
    Public Property MuteAll() As Boolean
        Get
            Return _MutedAll
        End Get
        Set(ByVal value As Boolean)
            _MutedAll = value
            If _MutedAll Then
                _Command = "setaudio " & _Alias & " off"
                _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
                If _Error <> 0 Then
                    RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "MuteAll: " & GetMciError(_Error)))
                End If
            Else
                _Command = "setaudio " & _Alias & " on"
                _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
                If _Error <> 0 Then
                    RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "MuteAll: " & GetMciError(_Error)))
                End If
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets mute status for left channel. Toggles mute on/off for left channel.
    ''' </summary>
    Public Property MuteLeft() As Boolean
        Get
            Return _MutedLeft
        End Get
        Set(ByVal value As Boolean)
            _MutedLeft = value
            If _MutedLeft Then
                _Command = "setaudio " & _Alias & " left off"
                _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
                If _Error <> 0 Then
                    RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "MuteLeft: " & GetMciError(_Error)))
                End If
            Else
                _Command = "setaudio " & _Alias & " left on"
                _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
                If _Error <> 0 Then
                    RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "MuteLeft: " & GetMciError(_Error)))
                End If
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets mute status for right channel. Toggles mute on/off for right channel.
    ''' </summary>
    Public Property MuteRight() As Boolean
        Get
            Return _MutedRight
        End Get
        Set(ByVal value As Boolean)
            _MutedRight = value
            If _MutedRight Then
                _Command = "setaudio " & _Alias & " right off"
                _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
                If _Error <> 0 Then
                    RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "MuteRight: " & GetMciError(_Error)))
                End If
            Else
                _Command = "setaudio " & _Alias & " right on"
                _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
                If _Error <> 0 Then
                    RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "MuteRight: " & GetMciError(_Error)))
                End If
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets/Sets volume for both channels. Min = 0, Max = 1000.
    ''' </summary>
    Public Property Volume() As Integer
        Get
            Return _Volume
        End Get
        Set(ByVal value As Integer)
            If _Opened And (value >= 0 And value <= 1000) Then
                _Volume = value
                _Command = String.Format("setaudio " & _Alias & " volume to {0}", _Volume)
                _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
                If _Error <> 0 Then
                    RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "VolumeAll: " & GetMciError(_Error)))
                End If
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets/Sets volume for left channel. Min = 0, Max = 1000.
    ''' </summary>
    Public Property VolumeLeft() As Integer
        Get
            Return _VolumeLeft
        End Get
        Set(ByVal value As Integer)
            If _Opened And (value >= 0 And value <= 1000) Then
                _VolumeLeft = value
                _Command = String.Format("setaudio " & _Alias & " left volume to {0}", _VolumeLeft)
                _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
                If _Error <> 0 Then
                    RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "VolumeLeft: " & GetMciError(_Error)))
                End If
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets/Sets volume for right channel. Min = 0, Max = 1000.
    ''' </summary>
    Public Property VolumeRight() As Integer
        Get
            Return _VolumeRight
        End Get
        Set(ByVal value As Integer)
            If _Opened And (value >= 0 And value <= 1000) Then
                _VolumeRight = value
                _Command = String.Format("setaudio " & _Alias & " right volume to {0}", _VolumeRight)
                _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
                If _Error <> 0 Then
                    RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "VolumeRight: " & GetMciError(_Error)))
                End If
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets/Sets treble volume for both channels. Min = 0, Max = 1000.
    ''' </summary>
    Public Property VolumeTreble() As Integer
        Get
            Return _VolumeTreble
        End Get
        Set(ByVal value As Integer)
            If _Opened And (value >= 0 And value <= 1000) Then
                _VolumeTreble = value
                _Command = String.Format("setaudio " & _Alias & " treble to {0}", _VolumeTreble)
                _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
                If _Error <> 0 Then
                    RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "VolumeTreble: " & GetMciError(_Error)))
                End If
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets/Sets bass volume for both channels. Min = 0, Max = 1000.
    ''' </summary>
    Public Property VolumeBass() As Integer
        Get
            Return _VolumeBass
        End Get
        Set(ByVal value As Integer)
            If _Opened And (value >= 0 And value <= 1000) Then
                _VolumeBass = value
                _Command = String.Format("setaudio " & _Alias & " bass to {0}", _VolumeBass)
                _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
                If _Error <> 0 Then
                    RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "VolumeBass: " & GetMciError(_Error)))
                End If
            End If
        End Set
    End Property

#End Region

#Region " Player Properties "

    ''' <summary>
    ''' Gets current filename.
    ''' </summary>
    Public ReadOnly Property FileName() As String
        Get
            Return _FileName
        End Get
    End Property

    ''' <summary>
    ''' Gets/Sets Looping (boolean).
    ''' </summary>
    Public Property Looping() As Boolean
        Get
            Return _Loop
        End Get
        Set(ByVal value As Boolean)
            _Loop = value
        End Set
    End Property

    ''' <summary>
    ''' Returns true if file is open.
    ''' </summary>
    Public ReadOnly Property Opened() As Boolean
        Get
            Return _Opened
        End Get
    End Property

    ''' <summary>
    ''' Returns true if file is playing.
    ''' </summary>
    Public ReadOnly Property Playing() As Boolean
        Get
            Return _Playing
        End Get
    End Property

    ''' <summary>
    ''' Returns true if file is paused.
    ''' </summary>
    Public ReadOnly Property Paused() As Boolean
        Get
            Return _Paused
        End Get
    End Property

    ''' <summary>
    ''' Gets the status of the media file.
    ''' </summary>
    Public ReadOnly Property Status() As String
        Get
            Dim buffer As StringBuilder = New StringBuilder(260)
            Dim ret As Integer = NativeMethods.mciSendString("STATUS " & _Alias & " MODE", buffer, buffer.Capacity, IntPtr.Zero)
            If ret <> 0 Then
                Return "unknown"
            Else
                Select Case buffer.ToString().ToLower()
                    Case "playing"
                        Return "playing"
                    Case "paused"
                        Return "paused"
                    Case "stopped"
                        Return "stopped"
                    Case Else
                        Return "unknown"
                End Select
            End If
        End Get
    End Property

#End Region

#Region " Public Events "

    Public Event OpenFile As EventHandler(Of OpenFileEventArgs)
    Public Event PlayFile As EventHandler(Of PlayFileEventArgs)
    Public Event PauseFile As EventHandler(Of PauseFileEventArgs)
    Public Event StopFile As EventHandler(Of StopFileEventArgs)
    Public Event CloseFile As EventHandler(Of CloseFileEventArgs)
    Public Event ErrorNumber As EventHandler(Of ErrorEventArgs)

#End Region

#Region " Public Methods "

    ''' <summary>
    ''' Seeks to position in milliseconds. Value must be less than length. File must be open.
    ''' </summary>
    Public Sub Seek(ByVal milliseconds As Long)

        If _Opened And milliseconds <= _Duration Then

            If _Playing Then

                If _Paused Then

                    _Command = String.Format("seek " & _Alias & " to {0}", milliseconds)
                    _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
                    If _Error <> 0 Then
                        RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "Seek: " & GetMciError(_Error)))
                    End If
                Else
                    _Command = String.Format("seek " & _Alias & " to {0}", milliseconds)
                    _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
                    If _Error <> 0 Then
                        RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "Seek: " & GetMciError(_Error)))
                    End If
                    _Command = "play " & _Alias & ""
                    _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
                    If _Error <> 0 Then
                        RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "Seek: " & GetMciError(_Error)))
                    End If
                End If
            End If
        End If

    End Sub

    ''' <summary>
    ''' Closes currently open file.
    ''' </summary>
    Public Sub Close()

        If _Opened Then

            _Command = "close " & _Alias & ""
            _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
            If _Error <> 0 Then
                RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "Close: " & GetMciError(_Error)))
            End If
            _Opened = False
            _Playing = False
            _Paused = False
            RaiseEvent CloseFile(Me, New CloseFileEventArgs())
        End If

    End Sub

    ''' <summary>
    ''' Opens sound file given path and filename.
    ''' </summary>
    Public Sub Open(ByVal fileName As String)

        If Not _Opened Then

            _Command = "open """ & fileName & """ type mpegvideo alias " & _Alias & ""
            _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
            If _Error <> 0 Then
                RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "Open: " & GetMciError(_Error)))
            End If
            _FileName = fileName
            _Opened = True
            _Playing = False
            _Paused = False
            _Command = "set " & _Alias & " time format milliseconds"
            _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
            If _Error <> 0 Then
                RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "Open: " & GetMciError(_Error)))
            End If
            _Command = "set " & _Alias & " seek exactly on"
            _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
            If _Error <> 0 Then
                RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "Open: " & GetMciError(_Error)))
            End If
            'CalculateDuration()
            RaiseEvent OpenFile(Me, New OpenFileEventArgs(fileName))
        Else
            Me.Close()
            Me.Open(fileName)
        End If

    End Sub

    ''' <summary>
    ''' Begins play or resumes from pause.
    ''' </summary>
    Public Sub Play()

        If _Opened Then

            If Not _Playing Then

                _Playing = True
                _Command = "play " & _Alias & ""
                If _Loop Then _Command &= " REPEAT"
                _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
                If _Error <> 0 Then
                    RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "Play: " & GetMciError(_Error)))
                End If
                RaiseEvent PlayFile(Me, New PlayFileEventArgs())
            Else
                If Not _Paused Then
                    _Command = "seek " & _Alias & " to start"
                    _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
                    If _Error <> 0 Then
                        RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "Play: " & GetMciError(_Error)))
                    End If
                    _Command = "play " & _Alias & ""
                    _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
                    If _Error <> 0 Then
                        RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "Play: " & GetMciError(_Error)))
                    End If
                    RaiseEvent PlayFile(Me, New PlayFileEventArgs())
                Else
                    _Paused = False
                    _Command = "play " & _Alias & ""
                    _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
                    If _Error <> 0 Then
                        RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "Play: " & GetMciError(_Error)))
                    End If
                    RaiseEvent PlayFile(Me, New PlayFileEventArgs())
                End If
            End If
        End If

    End Sub

    ''' <summary>
    ''' Toggles pause.
    ''' </summary>
    Public Sub Pause()

        If _Opened Then

            If Not _Paused Then
                _Paused = True
                _Command = "pause " & _Alias & ""
                _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
                If _Error <> 0 Then
                    RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "Pause: " & GetMciError(_Error)))
                End If
                RaiseEvent PauseFile(Me, New PauseFileEventArgs())
            Else
                _Paused = False
                _Command = "play " & _Alias & ""
                _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
                If _Error <> 0 Then
                    RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "Pause: " & GetMciError(_Error)))
                End If
                RaiseEvent PlayFile(Me, New PlayFileEventArgs())
            End If
        End If

    End Sub

    ''' <summary>
    ''' Stops play of open file.
    ''' </summary>
    Public Sub StopPlay()

        If _Opened And _Playing Then

            _Playing = False
            _Paused = False
            _Command = "seek " & _Alias & " to start"
            _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
            If _Error <> 0 Then
                RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "StopPlay: " & GetMciError(_Error)))
            End If
            _Command = "stop " & _Alias & ""
            _Error = NativeMethods.mciSendString(_Command, Nothing, 0, IntPtr.Zero)
            If _Error <> 0 Then
                RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "StopPlay: " & GetMciError(_Error)))
            End If
            RaiseEvent StopFile(Me, New StopFileEventArgs())
        End If

    End Sub

    ''' <summary>
    ''' Gets the duration of the file.
    ''' </summary>
    ''' <returns>An integer that holds the length of the file.</returns>
    ''' <remarks>The length is measured in milliseconds.</remarks>
    Public Function Duration() As Integer
        If _Opened Then
            Dim buffer As StringBuilder = New StringBuilder(260)
            _Error = NativeMethods.mciSendString("STATUS " & _Alias & " LENGTH", buffer, buffer.Capacity, IntPtr.Zero)
            If _Error <> 0 Then
                RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "Duration: " & GetMciError(_Error)))
                Return 0
            End If
            _Duration = Integer.Parse(buffer.ToString())
            Return _Duration
        Else
            _Duration = 0
            Return _Duration
        End If
    End Function

    ''' <summary>
    ''' Returns the position in the media file.
    ''' </summary>
    ''' <returns>An integer that specifies the position in the media file.</returns>
    ''' <exception cref="MediaException">An error occured while accessing the media.</exception>
    ''' <remarks>The position is measured in milliseconds.</remarks>
    Public Function CurrentPosition() As Integer
        If _Opened Then
            Dim buffer As StringBuilder = New StringBuilder(260)
            _Error = NativeMethods.mciSendString("STATUS " & _Alias & " POSITION", buffer, buffer.Capacity, IntPtr.Zero)
            If _Error <> 0 Then
                RaiseEvent ErrorNumber(Me, New ErrorEventArgs(_Error, "CurrentPosition: " & GetMciError(_Error)))
                Return 0
            End If
            Return Integer.Parse(buffer.ToString())
        Else
            Return 0
        End If
    End Function

    Public Function FormatTime(ByVal milliseconds As Integer) As String
        Dim seconds As Integer
        Dim minutes As Integer
        Dim hours As Integer

        seconds = CInt(milliseconds / 1000)

        If (seconds >= 3600) Then
            hours = CInt(Math.Floor(seconds / 3600))
            seconds = seconds - (hours * 3600)
        Else
            hours = 0
        End If

        If (seconds >= 60) Then
            minutes = CInt(Math.Floor(seconds / 60))
            seconds = seconds - (minutes * 60)
        Else
            minutes = 0
        End If

        Dim time As String = Format(minutes, "00") & ":" & Format(seconds, "00")
        If hours > 0 Then
            time = Format(hours, "00") & ":" & time
        End If

        Return CStr(time)

    End Function

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Converts an MCI error code into a string.
    ''' </summary>
    ''' <param name="errorCode">The error code to convert.</param>
    ''' <returns>A string representation of the specified error code -or- an empty string (="") when an error occurs.</returns>
    Protected Shared Function GetMciError(ByVal errorCode As Integer) As String
        Dim buffer As StringBuilder = New StringBuilder(255)
        If NativeMethods.mciGetErrorString(errorCode, buffer, buffer.Capacity) = 0 Then Return ""
        Return buffer.ToString()
    End Function

#End Region

End Class

#Region " Event Arg Classes "

Public Class OpenFileEventArgs
    Inherits EventArgs

    Private _FileName As String

    Public Sub New(ByVal fileName As String)
        _FileName = fileName
    End Sub

    Public ReadOnly Property FileName() As String
        Get
            Return _FileName
        End Get
    End Property

End Class

Public Class PlayFileEventArgs
    Inherits EventArgs

    Public Sub New()
    End Sub

End Class

Public Class PauseFileEventArgs
    Inherits EventArgs

    Public Sub New()
    End Sub

End Class

Public Class StopFileEventArgs
    Inherits EventArgs

    Public Sub New()
    End Sub

End Class

Public Class CloseFileEventArgs
    Inherits EventArgs

    Public Sub New()
    End Sub

End Class

Public Class ErrorEventArgs
    Inherits EventArgs

    Private _ErrorNumber As Long
    Private _Method As String

    Public Sub New(ByVal errorNumber As Long, ByVal method As String)
        _ErrorNumber = errorNumber
        _Method = method
    End Sub

    Public ReadOnly Property ErrorNumber() As Long
        Get
            Return _ErrorNumber
        End Get
    End Property

    Public ReadOnly Property Method() As String
        Get
            Return _Method
        End Get
    End Property

End Class

#End Region