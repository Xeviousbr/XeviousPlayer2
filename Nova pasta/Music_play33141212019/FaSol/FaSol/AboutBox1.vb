Public NotInheritable Class AboutBox1

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Contracte As String
        Dim ApplicationTitle As String

        Contracte = "CONTRACTE DE LLICÈNCIA D'USUARI"
        Contracte = Contracte & vbCrLf & vbCrLf & "El propietari del programari que es llicencia en aquest document, Joan Roca, cedeix en favor de l’usuari final registrat una llicència d’ús del seu producte."
        Contracte = Contracte & vbCrLf & vbCrLf & "Aquesta llicència d’ús és personal i intransferible, i referida únicament a la versió actual i registrada del programari l’ús del qual es cedeix, sense que atorgui cap dret sobre futures versions."

        Contracte = Contracte & vbCrLf & vbCrLf & "L’usuari final reconeix que el programa informàtic al que es refereix aquesta llicència és d’exclusiva propietat de Joan Roca i que ell tan sols adquireix el dret d’ús personal i intransferible, en una sola màquina o equip informàtic, comprometent-se a no cedir-lo a tercers, gratuïtament o no, a no modificar-lo o descompilar-lo de forma coneguda o no, i a no fer ús d’ell en xarxa sense l’expressa autorització del propietari."
        Contracte = Contracte & vbCrLf & vbCrLf & "Aquesta llicència es concedeix per temps indefinit, no obstant l'incompliment de l’usuari final registrat d’alguna de les condicions de la mateixa suposarà la seva extinció."
        Contracte = Contracte & vbCrLf & vbCrLf & "L’ús del programari emparat per aquesta llicència per l’usuari final implica l’acceptació tàcita i incondicional d’aquest del contingut d’aquesta llicència."
        Contracte = Contracte & vbCrLf & vbCrLf & "Vostè reconeix haver llegit el contracte de llicència i indica, mitjançant la instal•lació o utilització de qualssevol dels programaris referits en aquest contracte, la seva acceptació dels termes i condicions d’aquest document."
        Contracte = Contracte & vbCrLf & vbCrLf & "Aquest programa està protegit per lleis de drets d’autor i per tractats internacionals de drets d’autor, així com per altres lleis i tractats sobre la propietat intel•lectual."
        Contracte = Contracte & vbCrLf & vbCrLf & "©Joan Roca - jroca@cmail.cat"



        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("Quant a  {0}", ApplicationTitle)

        Me.LabelProductName.Text = "FaSol"
        Me.LabelVersion.Text = String.Format("Versió {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName

        Me.TextBoxDescription.Text = Contracte
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

End Class
