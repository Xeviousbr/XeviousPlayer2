Public Class Form1
    Dim llistaAlea As New List(Of Integer)
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        wmp.controls.stop()
        EscriureConfig("Volum", TrackBar2.Value)
        EscriureConfig("PosicioActual", TrackBar1.Value)
        EscriureConfig("AmpleColCami", ListView1.Columns(3).Width)
        If Me.Width < 1200 Then
            EscriureConfig("AmpleForm", 1200)
        Else
            EscriureConfig("AmpleForm", Me.Width)
        End If

        If Me.Height < 980 Then
            EscriureConfig("AlturaForm", 980)
        Else
            EscriureConfig("AlturaForm", Me.Height)
        End If

        If Me.Top < 0 Then
            EscriureConfig("FormTop", 0)
        Else
            EscriureConfig("FormTop", Me.Top)
        End If

        If Me.Left < 0 Then
            EscriureConfig("FormLeft", 0)
        Else
            EscriureConfig("FormLeft", Me.Left)
        End If

        EscriureConfig("FormState", Me.WindowState)


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer

        wmp.settings.autoStart = False
        ListView1.Columns(3).Width = LlegirIntConfig("AmpleColCami")
        Me.Width = LlegirIntConfig("AmpleForm")
        Me.Height = LlegirIntConfig("AlturaForm")
        Me.Left = LlegirIntConfig("FormLeft")
        Me.Top = LlegirIntConfig("FormTop")

        TrackBar2.Value = LlegirIntConfig("Volum")
        Label4.Text = "Volum: " & TrackBar2.Value

        wmp.settings.mute = Not LlegirBolConfig("VolumOn")
        wmp.settings.volume = TrackBar2.Value
        If wmp.settings.mute Then

            ToolStripButton4.Image = My.Resources.mut
        Else

            ToolStripButton4.Image = My.Resources.AltaveuOn
        End If
        For i = 0 To 9
            DeuUltims(i) = ""
        Next

        If LlegirBolConfig("IniciarPunt") And My.Computer.FileSystem.FileExists(LlegirStrConfig("FitxerLliActual")) Then

            Dim ia As Integer
            ia = LlegirIntConfig("ItemActual")
            AfegirLlista(False, LlegirStrConfig("FitxerLliActual"))
            ObtenirTempsTotal()

            PlayItem(ia, LlegirIntConfig("PosicioActual"))
            Timer2.Enabled = True

            llistaAlea.Remove(ia)

        End If
        Me.WindowState = LlegirIntConfig("FormState")

    End Sub

    Private Sub AfegirFitxersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AfegirFitxersToolStripMenuItem.Click
        Call AfegirFitxers(False)
        ObtenirTempsTotal()
    End Sub

    Private Sub EsborrarLlistaIAfegirFitxersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EsborrarLlistaIAfegirFitxersToolStripMenuItem.Click
        Call AfegirFitxers(True)
        ObtenirTempsTotal()
    End Sub
    Sub AfegirFitxers(bEsborrarLlista As Boolean)
        Dim iter As Integer = 0
        Dim iNLlista As Integer = 0
        Dim iNumElem As Integer
        Dim sFi As String

        opn.Filter = "Fitxers d'audio (*.mp3;*.mp4;*.wav)|*.mp3;*.mp4;*.wav"
        If opn.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        If bEsborrarLlista Then
            For Each it In ListView1.Items
                it.remove()
            Next

            iIndexDeCançoActual = -1
        End If
        iNLlista = ListView1.Items.Count
        iNumElem = opn.FileNames.Count()
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Maximum = iNumElem

        For iter = 0 To iNumElem - 1
            sFi = opn.FileNames(iter)
            Dim m As WMPLib.IWMPMedia = wmp.newMedia(sFi)

            ListView1.Items.Add("")
            ListView1.Items(iter + iNLlista).SubItems.Add(iter + iNLlista + 1)
            ListView1.Items(iter + iNLlista).SubItems.Add(m.durationString)
            ListView1.Items(iter + iNLlista).SubItems.Add(sFi)
            ToolStripStatusLabel4.Text = iter + iNLlista + 1 & "/" & iNumElem + iNLlista
            ToolStripProgressBar1.Value = iter + 1

            Application.DoEvents()
        Next
        ToolStripProgressBar1.Value = 0
        DesarLlista(My.Application.Info.DirectoryPath & "\" & "TempLli.lli")

        EscriureConfig("FitxerLliActual", My.Application.Info.DirectoryPath & "\" & "TempLli.lli")
    End Sub
    Sub AfegirCarpeta(bEsborrarLlista As Boolean)
        Dim iter As Integer = 0
        Dim iNumElem As Integer
        Dim iNLlista As Integer = 0
        If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        If bEsborrarLlista Then
            For Each it In ListView1.Items
                it.remove()
            Next

            iIndexDeCançoActual = -1
        End If
        iNLlista = ListView1.Items.Count

        Dim list As List(Of String) = GetFilesRecursive(FolderBrowserDialog1.SelectedPath)
        list.Sort()
        iNumElem = list.Count
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Maximum = iNumElem

        For Each path In list
            Dim m As WMPLib.IWMPMedia = wmp.newMedia(path)
            ListView1.Items.Add("")
            ListView1.Items(iter + iNLlista).SubItems.Add(iter + iNLlista + 1)
            ListView1.Items(iter + iNLlista).SubItems.Add(m.durationString)
            ListView1.Items(iter + iNLlista).SubItems.Add(path)
            iter = iter + 1
            ToolStripStatusLabel4.Text = iter + iNLlista & "/" & iNumElem + iNLlista
            ToolStripProgressBar1.Value = iter

            Application.DoEvents()
        Next

        ToolStripProgressBar1.Value = 0

        DesarLlista(My.Application.Info.DirectoryPath & "\" & "TempLli.lli")
        EscriureConfig("FitxerLliActual", My.Application.Info.DirectoryPath & "\" & "TempLli.lli")
    End Sub
    Sub AfegirLlista(bEsborrarLlista As Boolean, Optional sFitxer As String = "")
        Dim iter As Integer = 0
        Dim iNumElem As Integer
        Dim iNLlista As Integer = 0
        Dim LineaTexto As String
        Dim aValors() As String
        llistaAlea.Clear()
        If sFitxer = "" Then
            opn.Filter = "Fitxers lli (*.lli)|*.lli"
            If opn.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
            sFitxer = opn.FileName

        End If
        If bEsborrarLlista Then

            For Each it In ListView1.Items
                it.remove()
            Next
            iIndexDeCançoActual = -1
        End If
        iNLlista = ListView1.Items.Count


        Dim file = My.Computer.FileSystem.OpenTextFileReader(sFitxer)

        LineaTexto = file.ReadLine
        iNumElem = CInt(LineaTexto)
        ToolStripProgressBar1.Value = 0
        ToolStripProgressBar1.Maximum = iNumElem
        LineaTexto = file.ReadLine

        While (LineaTexto <> Nothing)

            aValors = LineaTexto.Split("|")
            ListView1.Items.Add("")
            ListView1.Items(iter + iNLlista).SubItems.Add(iter + iNLlista + 1)
            ListView1.Items(iter + iNLlista).SubItems.Add(aValors(0))
            ListView1.Items(iter + iNLlista).SubItems.Add(aValors(1))

            ListView1.Items(iter + iNLlista).EnsureVisible()
            iter = iter + 1
            ToolStripStatusLabel4.Text = iter + iNLlista & "/" & iNumElem + iNLlista
            ToolStripProgressBar1.Value = iter

            Application.DoEvents()
            LineaTexto = file.ReadLine()
        End While

        ToolStripProgressBar1.Value = 0

        EscriureConfig("FitxerLliActual", sFitxer)
        file.Close()
    End Sub
    Sub PlayItem(iItem As Integer, Optional lPosicio As Long = 0)
        Dim iNLlista As Integer
        Dim sCami As String
        Dim i As Integer


        sCami = ListView1.Items(iItem).SubItems(3).Text
        iIndexDeCançoActual = iItem
        For i = 9 To 1 Step -1
            DeuUltims(i) = DeuUltims(i - 1)
        Next
        DeuUltims(0) = sCami

        If My.Computer.FileSystem.FileExists(sCami) Then
            Dim m As WMPLib.IWMPMedia = wmp.newMedia(sCami)
            wmp.URL = sCami
            For Each it In ListView1.Items
                it.text = ""
                it.selected = False
            Next
            iNLlista = ListView1.Items.Count
            ListView1.Items(iItem).Text = "♫"
            ListView1.Items(iItem).Selected = True
            If LlegirBolConfig("MantenirVisible") Then
                ListView1.Items(iItem).EnsureVisible()
            End If

            wmp.controls.play()
            wmp.controls.currentPosition = lPosicio
            TrackBar1.Maximum = m.duration
            TrackBar1.Value = lPosicio
            Label1.Text = ListView1.Items(iItem).SubItems(2).Text
            ToolStripStatusLabel4.Text = iItem + 1 & "/" & iNLlista
            EscriureConfig("ItemActual", iItem)
            Timer1.Enabled = True

        Else
            ListView1.Items(iItem).SubItems(3).Text = "ERROR: Camí mort: " & ListView1.Items(iItem).SubItems(3).Text
            PlaySeguent()
        End If
    End Sub
    Sub PlaySeguent()
        Dim iIndexUltim As Integer = -1
        Dim iNLlista As Integer
        Dim iAleatori As Integer

        iNLlista = ListView1.Items.Count

        Select Case LlegirBolConfig("Aleatori")
            Case True
                Randomize()
                iAleatori = CInt(Int(((iNLlista - 1) * Rnd())))

                PlayItem(iAleatori)

            Case False
                iIndexUltim = iNLlista - 1
                If iIndexUltim = iIndexDeCançoActual Then iIndexDeCançoActual = -1
                PlayItem(iIndexDeCançoActual + 1)

        End Select
    End Sub
    Private Sub AfegirCarpetaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AfegirCarpetaToolStripMenuItem.Click
        Call AfegirCarpeta(False)
        ObtenirTempsTotal()
    End Sub

    Private Sub EsborrarLlistaIAfegirCarpetaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EsborrarLlistaIAfegirCarpetaToolStripMenuItem.Click
        Call AfegirCarpeta(True)
        ObtenirTempsTotal()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label2.Text = wmp.controls.currentPositionString

        If Me.TrackBar1.Value = Me.TrackBar1.Maximum Then
            Timer1.Enabled = False
            PlaySeguent()
        Else
            TrackBar1.Value = TrackBar1.Value + 1
            Label3.Text = "Progrés: " & CInt(wmp.controls.currentPosition / TrackBar1.Maximum * 100) & " %"

        End If
    End Sub

    

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        wmp.settings.volume = TrackBar2.Value
        Label4.Text = "Volum: " & TrackBar2.Value
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick
        PlayItem(ListView1.SelectedItems(0).Index)
    End Sub


    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs)
        wmp.controls.stop()
        Timer1.Enabled = False
        For Each it In ListView1.Items
            it.text = ""
        Next
        TrackBar1.Value = 0
        Label1.Text = "00:00"
        Label2.Text = "00:00"
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        If wmp.URL = "" Or wmp.playState = WMPLib.WMPPlayState.wmppsStopped Then
            MsgBox("No sona cap cançò de la llista", MsgBoxStyle.Exclamation, "Error")
            TrackBar1.Value = 0
        Else
            wmp.controls.currentPosition = Me.TrackBar1.Value
            Label2.Text = wmp.controls.currentPositionString

        End If
    End Sub

    Private Sub DesarLlistaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesarLlistaToolStripMenuItem.Click
        sfd.DefaultExt = "lli"
        sfd.Filter = "Fitxers lli (*.lli)|*.lli"
        sfd.ShowDialog()
        If Windows.Forms.DialogResult.OK Then
            DesarLlista(sfd.FileName)
        End If
    End Sub

    Private Sub AfegirLlistaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AfegirLlistaToolStripMenuItem.Click
        AfegirLlista(False)
        ObtenirTempsTotal()
    End Sub

    Private Sub EsborrarLlistaIAfegirLlistaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EsborrarLlistaIAfegirLlistaToolStripMenuItem.Click
        AfegirLlista(True)
        ObtenirTempsTotal()
    End Sub

    Private Sub QuantAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuantAToolStripMenuItem.Click
        AboutBox1.ShowDialog()

    End Sub
    Sub ObtenirTempsTotal()
        Dim iSegonsTotals As Long

        For Each it In ListView1.Items
            iSegonsTotals = iSegonsTotals + ReturnSeconds(it.SubItems(2).text())

        Next
        Dim span4 As TimeSpan = TimeSpan.FromSeconds(iSegonsTotals)
        ToolStripStatusLabel3.Text = span4.ToString

    End Sub

    Private Sub OrdreProgressiuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdreProgressiuToolStripMenuItem.Click

        EscriureConfig("Aleatori", False)
        OrdreProgressiuToolStripMenuItem.Checked = True
        OrdreAleatoriToolStripMenuItem.Checked = False
    End Sub

    Private Sub OrdreAleatoriToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrdreAleatoriToolStripMenuItem.Click

        EscriureConfig("Aleatori", True)
        OrdreProgressiuToolStripMenuItem.Checked = False
        OrdreAleatoriToolStripMenuItem.Checked = True

    End Sub



    Private Sub MantenirLaFilaVisibleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenirLaFilaVisibleToolStripMenuItem.Click

        MantenirLaFilaVisibleToolStripMenuItem.Checked = Not MantenirLaFilaVisibleToolStripMenuItem.Checked

        EscriureConfig("MantenirVisible", MantenirLaFilaVisibleToolStripMenuItem.Checked)
    End Sub

    Private Sub IniciarEnElPuntQueEstavaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IniciarEnElPuntQueEstavaToolStripMenuItem.Click


        IniciarEnElPuntQueEstavaToolStripMenuItem.Checked = Not IniciarEnElPuntQueEstavaToolStripMenuItem.Checked

        EscriureConfig("IniciarPunt", IniciarEnElPuntQueEstavaToolStripMenuItem.Checked)

    End Sub
  
    Sub Reordenarllista()
        Dim iter As Integer = 0
        For Each it In ListView1.Items
            iter = iter + 1
            it.subitems(1).text = iter
        Next
    End Sub
    Private Sub EliminarCançonsSeleccionadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarCançonsSeleccionadesToolStripMenuItem.Click


        For Each it In ListView1.SelectedItems
            it.remove()

        Next

        Reordenarllista()
        ObtenirTempsTotal()

    End Sub

    Private Sub ObrirCarpetaDeLaCançóSeleccionadaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ObrirCarpetaDeLaCançóSeleccionadaToolStripMenuItem.Click
        Dim filePath As String = ListView1.SelectedItems(0).SubItems(3).Text
        Dim directoryPath As String = IO.Path.GetDirectoryName(filePath)


        Process.Start(directoryPath)
    End Sub

    Private Sub CopiarCamíToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiarCamíToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(ListView1.SelectedItems(0).SubItems(3).Text)
    End Sub



    Sub DesarLlista(sFileLli As String)
        If sFileLli <> "" Then

            Dim file = My.Computer.FileSystem.OpenTextFileWriter(sFileLli, False)
            file.WriteLine(ListView1.Items.Count)
            For Each it In ListView1.Items
                file.WriteLine(it.subitems(2).text() & "|" & it.subitems(3).text())
            Next

            file.Close()
        End If
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ListView1.Height = Me.Height - 65 - ListView1.Top
        ListView1.Width = Me.Width - 18

    End Sub

    Private Sub LlistaToolStripMenuItem_Paint(sender As Object, e As PaintEventArgs) Handles LlistaToolStripMenuItem.Paint

        OrdreProgressiuToolStripMenuItem.Checked = Not LlegirBolConfig("Aleatori")
        OrdreAleatoriToolStripMenuItem.Checked = LlegirBolConfig("Aleatori")
        MantenirLaFilaVisibleToolStripMenuItem.Checked = LlegirBolConfig("MantenirVisible")
        IniciarEnElPuntQueEstavaToolStripMenuItem.Checked = LlegirBolConfig("IniciarPunt")

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        Select Case LlegirStrConfig("PlayEstat")
            Case "Play"


                ToolStripButton1.Image = My.Resources.playon
                ToolStripButton2.Image = My.Resources.pauseof
                ToolStripButton3.Image = My.Resources.stopof


            Case "Pause"

                ToolStripButton1.Image = My.Resources.playof
                ToolStripButton2.Image = My.Resources.pauseon
                ToolStripButton3.Image = My.Resources.stopof
                wmp.controls.pause()
                Timer1.Enabled = False
            Case "Stop"

                ToolStripButton1.Image = My.Resources.playof
                ToolStripButton2.Image = My.Resources.pauseof
                ToolStripButton3.Image = My.Resources.stopon
                wmp.controls.stop()
                Timer1.Enabled = False
        End Select
        Timer2.Enabled = False
    End Sub


    Private Sub EditarTagsDeLaCançóSeleccionadaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarTagsDeLaCançóSeleccionadaToolStripMenuItem.Click
        frmTags.ShowDialog()
    End Sub



    Private Sub EliminarCançonsAmbCamíMortToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarCançonsAmbCamíMortToolStripMenuItem.Click
        Dim fla As Boolean = False

        For Each it In ListView1.Items

            If Not My.Computer.FileSystem.FileExists(it.subitems(3).text) Then
                it.remove()
                fla = True
            End If

        Next
        If fla Then
            Reordenarllista()
            ObtenirTempsTotal()

        End If
    End Sub

    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        wmp.controls.pause()
        Timer1.Enabled = False


        ToolStripButton1.Image = My.Resources.playof
        ToolStripButton2.Image = My.Resources.pauseon
        ToolStripButton3.Image = My.Resources.stopof

        EscriureConfig("PlayEstat", "Pause")


    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        wmp.settings.mute = Not wmp.settings.mute

        If wmp.settings.mute Then

            ToolStripButton4.Image = My.Resources.mut

            EscriureConfig("VolumOn", False)
        Else

            ToolStripButton4.Image = My.Resources.AltaveuOn

            EscriureConfig("VolumOn", True)
        End If

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        wmp.controls.play()
        Timer1.Enabled = True
        ToolStripButton1.Image = My.Resources.playon
        ToolStripButton2.Image = My.Resources.pauseof
        ToolStripButton3.Image = My.Resources.stopof

        EscriureConfig("PlayEstat", "Play")
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        wmp.controls.stop()
        Timer1.Enabled = False
        TrackBar1.Value = 0
        Label2.Text = "00:00"


        ToolStripButton1.Image = My.Resources.playof
        ToolStripButton2.Image = My.Resources.pauseof
        ToolStripButton3.Image = My.Resources.stopon

        EscriureConfig("PlayEstat", "Stop")

    End Sub

    Private Sub BuscarCançóDeLaLlistaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarCançóDeLaLlistaToolStripMenuItem.Click
        Dim sTx As String
        Dim sBuscar As String = ""
        sBuscar = InputBox("Escriu el nom de la cançó. Tot o una part. Les cançons trobades quedaran seleccionades.", "Buscar Cançó")
        For Each it In ListView1.Items
            sTx = it.subitems(3).text()
            If InStr(sTx, sBuscar) <> 0 Then
                it.selected = True
            End If
        Next

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        AboutBox1.ShowDialog()
    End Sub

    Private Sub TempsTotalDeLesCançonsSeleccionadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TempsTotalDeLesCançonsSeleccionadesToolStripMenuItem.Click
        Dim iNum As Integer = 0
        Dim iSegons As Integer

        iNum = ListView1.SelectedItems.Count

        For Each it In ListView1.SelectedItems
            iSegons = iSegons + ReturnSeconds(it.SubItems(2).text())
        Next
        MsgBox("Seleccionades: " & iNum & vbCrLf & "Temps total: " & SegonsFormatTemps(iSegons))
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        frmDeuUltims.Show()
    End Sub

    Private Sub SortirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SortirToolStripMenuItem.Click
        End
    End Sub
End Class
