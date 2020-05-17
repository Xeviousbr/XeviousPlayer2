#Region "Imports"

Imports PVS.MediaPlayer

#End Region

Public Class Overlay

    ' This is a sample PVS.MediaPlayer display overlay:
    ' it shows a label with the text "Display Overlay" on top of movies.
    ' As an example of overlay 'animation' the text is made 'flashing'.

    ' The background color is 'close' to the text color to prevent
    ' visible 'borders' around the letters of the text.

    ' The text remains in the middle of the video image because
    ' the label is 'anchored' on all sides of the form and the
    ' text is centered (TextAlign MiddleCenter).

    ' The display overlay (form) also contains a label
    ' that is used to display subtitles.


    ' Special items (optional but highly recommended - see code below):

    ' A few options (ShowWithoutActivation and (overwrite) WndProc) are used to prevent 'flashing'
    ' of the overlay when it is displayed or clicked on.

    ' To use the player option to drag the display window, you must use a mousedown eventhandler
    ' provided by the player (Player.Display.Drag_MouseDown) for the overlay and any control on it
    ' (which must start dragging the display of the player when clicked).

    ' The 'heart' of every display overlay is the VisibleChanged event handler. It is called when
    ' the overlay is activated or deactivated.


    ' About the transparency of display overlays:

    ' PVS.MediaPlayer makes overlays transparent by setting the TransparencyKey property of the overlay
    ' (form) to the same color as the background color of the overlay. You can set these colors yourself
    ' if you want. The 'mouseclick transparency' of the overlay depends on the colors used. For example,
    ' 'Green' makes mouse clicks 'fall through', but 'RosyBrown' does not.
    ' More information can be found on the internet.


    ' **** Class Fields ***************************************************************************

#Region "Class fields"

    Private ReadOnly FOREGROUND_COLOR As Color = Color.Red ' = 255, 0, 0
    'Private ReadOnly BACKGROUND_COLOR As Color = Color.FromArgb(200, 0, 0)
    Private Const TIMER_INTERVAL As Integer = 600

    Private basePlayer As Player    ' used with dragging the player's display
    Private flashTimer As Timer     ' the timer used for flashing text
    Private flashOn As Boolean      ' the state of the flashing text
    Private wasDisposed As Boolean  ' used with cleaning up

#End Region

    ' **** Main ***************************************************************************

#Region "Main"

    Public Sub New(player As Player)

        InitializeComponent() ' this call is required by the designer.
        basePlayer = player

        subtitlesLabel.Text = ""

        flashTimer = New Timer()
        flashTimer.Interval = TIMER_INTERVAL
        AddHandler flashTimer.Tick, AddressOf FlashTimer_Tick

    End Sub

    ' Don't activate form when shown
    Protected Overrides ReadOnly Property ShowWithoutActivation() As Boolean
        Get
            Return True
        End Get
    End Property

    ' Don't activate form with mouse click
    Protected Overrides Sub WndProc(ByRef m As Message)

        Const WM_MOUSEACTIVATE As Integer = &H21
        Const MA_NOACTIVATE As Integer = &H3

        If (m.Msg = WM_MOUSEACTIVATE) Then
            m.Result = CType(MA_NOACTIVATE, IntPtr)
        Else
            MyBase.WndProc(m)
        End If

    End Sub

    ' The animation (timer) is switched on/off when the form's visibility changes,
    ' The form's visibility (among other) changes when the overlay is activated/deactivated by the player:
    Private Sub Overlay_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged

        If Visible Then
            flashOn = False
            flashLabel.ForeColor = FOREGROUND_COLOR
            flashTimer.Start()

            ' enable dragging of the main display (if  enabled)
            AddHandler MouseDown, AddressOf basePlayer.Display.Drag_MouseDown
            AddHandler flashLabel.MouseDown, AddressOf basePlayer.Display.Drag_MouseDown
            AddHandler subtitlesLabel.MouseDown, AddressOf basePlayer.Display.Drag_MouseDown
        Else
            flashTimer.Stop()

            ' disable dragging of the main display (if  enabled)
            RemoveHandler MouseDown, AddressOf basePlayer.Display.Drag_MouseDown
            RemoveHandler flashLabel.MouseDown, AddressOf basePlayer.Display.Drag_MouseDown
            RemoveHandler subtitlesLabel.MouseDown, AddressOf basePlayer.Display.Drag_MouseDown
        End If

    End Sub

    ' Here the 'animation' (text flashing) is done
    Private Sub FlashTimer_Tick(sender As Object, e As EventArgs)

        If flashOn Then
            flashLabel.Text = "Display Overlay"
        Else
            flashLabel.Text = ""
        End If
        flashOn = Not flashOn

    End Sub

    ' Clean Up - this is moved here from the 'Overlay.Designer.vb' file and appended:
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If Not wasDisposed Then
                wasDisposed = True
                If disposing Then
                    If (flashTimer IsNot Nothing) Then flashTimer.Dispose()
                    ' used by the designer - clean up:
                    If components IsNot Nothing Then components.Dispose()
                End If
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

#End Region

End Class

#Region "BlendLabel"

' A replacement for the standard label to allow for overlay opacity on display clones and certain screen copies.
' Just copy this class to your application and replace the standard labels on display overlays with a BlendLabel.

Public Class BlendLabel : Inherits Label

    Dim _stringFormat As StringFormat

    Public Sub New()
        _stringFormat = New StringFormat
        _stringFormat.Alignment = StringAlignment.Near
        _stringFormat.LineAlignment = StringAlignment.Near
    End Sub

    Public Overrides Property TextAlign As ContentAlignment
        Get
            Return MyBase.TextAlign
        End Get

        Set(value As ContentAlignment)

            If Not value = MyBase.TextAlign Then

                MyBase.TextAlign = value

                Select Case value

                    Case ContentAlignment.TopLeft
                        _stringFormat.Alignment = StringAlignment.Near
                        _stringFormat.LineAlignment = StringAlignment.Near

                    Case ContentAlignment.TopCenter
                        _stringFormat.Alignment = StringAlignment.Center
                        _stringFormat.LineAlignment = StringAlignment.Near

                    Case ContentAlignment.TopRight
                        _stringFormat.Alignment = StringAlignment.Far
                        _stringFormat.LineAlignment = StringAlignment.Near


                    Case ContentAlignment.MiddleLeft
                        _stringFormat.Alignment = StringAlignment.Near
                        _stringFormat.LineAlignment = StringAlignment.Center

                    Case ContentAlignment.MiddleCenter
                        _stringFormat.Alignment = StringAlignment.Center
                        _stringFormat.LineAlignment = StringAlignment.Center

                    Case ContentAlignment.MiddleRight
                        _stringFormat.Alignment = StringAlignment.Far
                        _stringFormat.LineAlignment = StringAlignment.Center


                    Case ContentAlignment.BottomLeft
                        _stringFormat.Alignment = StringAlignment.Near
                        _stringFormat.LineAlignment = StringAlignment.Far

                    Case ContentAlignment.BottomCenter
                        _stringFormat.Alignment = StringAlignment.Center
                        _stringFormat.LineAlignment = StringAlignment.Far

                    Case ContentAlignment.BottomRight
                        _stringFormat.Alignment = StringAlignment.Far
                        _stringFormat.LineAlignment = StringAlignment.Far

                End Select

                Invalidate()

            End If
        End Set
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        'MyBase.OnPaint(e)
        Dim b As SolidBrush = New SolidBrush(Me.ForeColor)
        e.Graphics.DrawString(Me.Text, Me.Font, b, Me.ClientRectangle, _stringFormat)
        b.Dispose()
    End Sub

End Class

#End Region