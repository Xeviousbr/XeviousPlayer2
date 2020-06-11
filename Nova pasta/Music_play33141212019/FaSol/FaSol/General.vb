Imports System.IO
Module General
    Public wmp As New WMPLib.WindowsMediaPlayer
    Public iIndexDeCançoActual As Integer
    Public DeuUltims(10) As String
    Public IndexDeuUltims As Integer


    Function ReturnSeconds(ByVal strTime As String) As Integer
        Dim strHours As String
        Dim strMinutes As String
        Dim strSeconds As String

        Dim arrTime() As String

        arrTime = strTime.Split(":")
        If arrTime.Count < 3 Then
            strHours = "00"
            strMinutes = arrTime(0)
            strSeconds = arrTime(1)
        Else
            strHours = arrTime(0)
            strMinutes = arrTime(1)
            strSeconds = arrTime(2)
        End If
        ReturnSeconds = strHours * 60 * 60
        ReturnSeconds += strMinutes * 60
        ReturnSeconds += strSeconds


    End Function
    Function SegonsFormatTemps(iSeg As Integer) As String
        Dim iSpan As TimeSpan = TimeSpan.FromSeconds(iSeg)
        SegonsFormatTemps = iSpan.Hours.ToString.PadLeft(2, "0"c) & ":" & _
                                iSpan.Minutes.ToString.PadLeft(2, "0"c) & ":" & _
                                iSpan.Seconds.ToString.PadLeft(2, "0"c)
    End Function
    Public Function GetFilesRecursive(ByVal initial As String) As List(Of String)
        ' This list stores the results.
        Dim result As New List(Of String)

        ' This stack stores the directories to process.
        Dim stack As New Stack(Of String)

        ' Add the initial directory
        stack.Push(initial)

        ' Continue processing for each stacked directory
        Do While (stack.Count > 0)
            ' Get top directory string
            Dim dir As String = stack.Pop
            Try
                ' Add all immediate file paths
                result.AddRange(Directory.GetFiles(dir, "*.mp3"))
                result.AddRange(Directory.GetFiles(dir, "*.mp4"))
                result.AddRange(Directory.GetFiles(dir, "*.mid"))
                result.AddRange(Directory.GetFiles(dir, "*.wav"))
                ' Loop through all subdirectories and add them to the stack.
                Dim directoryName As String
                For Each directoryName In Directory.GetDirectories(dir)
                    stack.Push(directoryName)
                Next

            Catch ex As Exception
            End Try
        Loop

        ' Return the list
        Return result
    End Function

End Module
