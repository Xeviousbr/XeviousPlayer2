Public Class frmTags

    Private Sub frmTags_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txname.Text = wmp.controls.currentItem.name
        Me.txalbum.Text = wmp.controls.currentItem.getItemInfo("WM/AlbumTitle")
        Me.txartist.Text = wmp.controls.currentItem.getItemInfo("WM/AlbumArtist")
        Me.txcomposer.Text = wmp.controls.currentItem.getItemInfo("WM/Composer")
        Me.txpublisher.Text = wmp.controls.currentItem.getItemInfo("WM/Publisher")
        Me.txyear.Text = wmp.controls.currentItem.getItemInfo("WM/Year")
        Me.txgenre.Text = wmp.controls.currentItem.getItemInfo("WM/Genre")
    End Sub

    

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            wmp.controls.currentItem.setItemInfo("WM/AlbumTitle", Me.txalbum.Text)
            wmp.controls.currentItem.setItemInfo("WM/AlbumArtist", Me.txartist.Text)
            wmp.controls.currentItem.setItemInfo("WM/Composer", Me.txcomposer.Text)
            wmp.controls.currentItem.setItemInfo("WM/Publisher", Me.txpublisher.Text)
            wmp.controls.currentItem.setItemInfo("WM/Year", Me.txyear.Text)
            wmp.controls.currentItem.setItemInfo("WM/Genre", Me.txgenre.Text)
        Catch
        End Try
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class