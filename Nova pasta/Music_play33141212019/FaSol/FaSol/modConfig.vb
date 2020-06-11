Imports System
Imports System.IO
Module modConfig
    Private Const sNomFileConfig = "Config.cfg"
    Friend Function LlegirStrConfig(sElement As String) As String
        Dim sFitxer As String = ""
        Dim line As String = ""
        Dim splitline(2) As String
        LlegirStrConfig = ""

        sFitxer = My.Application.Info.DirectoryPath & "\" & sNomFileConfig
        If Not My.Computer.FileSystem.FileExists(sFitxer) Then
            Exit Function

        End If
        Dim sr As StreamReader = New StreamReader(sFitxer)
        Do
            line = sr.ReadLine()
            If line Is Nothing Then Exit Do
            splitline = line.Split("=")
            If splitline(0) = sElement Then
                LlegirStrConfig = splitline(1)
                Exit Do
            End If

        Loop Until line Is Nothing
        sr.Close()
    End Function
    Friend Function LlegirBolConfig(sElement As String) As Boolean
        Dim sFitxer As String = ""
        Dim line As String = ""
        Dim splitline(2) As String
        LlegirBolConfig = False

        sFitxer = My.Application.Info.DirectoryPath & "\" & sNomFileConfig
        If Not My.Computer.FileSystem.FileExists(sFitxer) Then
            Exit Function

        End If
        Dim sr As StreamReader = New StreamReader(sFitxer)
        Do
            line = sr.ReadLine()
            If line Is Nothing Then Exit Do
            splitline = line.Split("=")
            If splitline(0) = sElement Then
                If splitline(1) = "True" Or splitline(1) = "true" Or splitline(1) = "1" Then
                    LlegirBolConfig = True
                End If
                Exit Do
            End If

        Loop Until line Is Nothing
        sr.Close()
    End Function
    Friend Function LlegirIntConfig(sElement As String) As Integer
        Dim sFitxer As String = ""
        Dim line As String = ""
        Dim splitline(2) As String
        LlegirIntConfig = 0

        sFitxer = My.Application.Info.DirectoryPath & "\" & sNomFileConfig
        If Not My.Computer.FileSystem.FileExists(sFitxer) Then
            Exit Function

        End If
        Dim sr As StreamReader = New StreamReader(sFitxer)
        Try

            Do
                line = sr.ReadLine()
                If line Is Nothing Then Exit Do
                splitline = line.Split("=")
                If splitline(0) = sElement Then
                    If splitline(1) = "" Or splitline(1) Is Nothing Then
                        LlegirIntConfig = 0
                    Else
                        LlegirIntConfig = CDbl(splitline(1))
                    End If

                    Exit Do
                End If

            Loop Until line Is Nothing
        Catch ex As Exception

        End Try
        sr.Close()

    End Function

    Friend Function LlegirDouConfig(sElement As String) As Double
        Dim sFitxer As String = ""
        Dim line As String = ""
        Dim splitline(2) As String
        LlegirDouConfig = 0

        sFitxer = My.Application.Info.DirectoryPath & "\" & sNomFileConfig
        If Not My.Computer.FileSystem.FileExists(sFitxer) Then
            Exit Function

        End If
        Try

            Dim sr As StreamReader = New StreamReader(sFitxer)
            Do
                line = sr.ReadLine()
                If line Is Nothing Then Exit Do
                splitline = line.Split("=")
                If splitline(0) = sElement Then
                    If splitline(1) = "" Or splitline(1) Is Nothing Then
                        LlegirDouConfig = 0
                    Else
                        LlegirDouConfig = CDbl(splitline(1))
                    End If

                    Exit Do
                End If

            Loop Until line Is Nothing
            sr.Close()
        Catch ex As Exception

        End Try

    End Function

    Friend Sub EscriureConfig(sElement As String, sValor As String)
        Dim sFitxer As String = ""
        Dim line As String = ""
        Dim lines() As String
        Dim splitline(2) As String
        Dim iter As Integer = 0
        Dim tr As Boolean = False
        sFitxer = My.Application.Info.DirectoryPath & "\" & sNomFileConfig
        If Not My.Computer.FileSystem.FileExists(sFitxer) Then
            Dim fs As FileStream = File.Create(sFitxer)
            fs.Close()
        End If
        Dim sr As StreamReader = New StreamReader(sFitxer)
        Do
            ReDim Preserve lines(iter + 1)
            line = "" & sr.ReadLine()
            lines(iter) = line
            splitline = lines(iter).Split("=")
            If splitline(0) = sElement Then
                splitline(1) = sValor
                lines(iter) = splitline(0) & "=" & splitline(1)
                tr = True
            End If
            iter = iter + 1

        Loop Until line = ""
        sr.Close()

        Dim sw As StreamWriter = New StreamWriter(sFitxer, False)
        For Each li In lines
            If li <> "" Then
                sw.WriteLine(li)

            End If
        Next
        If Not tr Then
            sw.WriteLine(sElement & "=" & sValor)
        End If

        sw.Close()

    End Sub
End Module
