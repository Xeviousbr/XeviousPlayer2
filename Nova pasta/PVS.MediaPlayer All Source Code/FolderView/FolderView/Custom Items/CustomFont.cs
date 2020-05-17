#region Usings

using System.Drawing;
using System.Drawing.Text;
using System.IO;

#endregion

namespace FolderView
{
    public partial class MainWindow
    {
        // ******************************** Install Private FontCollection and create Fonts

        #region Install Private FontCollection and create Fonts

        private void InstallCustomFonts()
        {
            Globals.FontCollection1 = new PrivateFontCollection();
            Stream fontStream = GetType().Assembly.GetManifestResourceStream("FolderView.Resources.Crystal Italic1.ttf");
            byte[] fontData = new byte[fontStream.Length];
            fontStream.Read(fontData, 0, (int)fontStream.Length);
            fontStream.Close();
            unsafe
            {
                fixed (byte* pFontData = fontData)
                {
                    Globals.FontCollection1.AddMemoryFont((System.IntPtr)pFontData, fontData.Length);
                }
            }

            Globals.CrystalFont16 = new Font(Globals.FontCollection1.Families[0], 16, FontStyle.Italic);
            Globals.CrystalFont26 = new Font(Globals.FontCollection1.Families[0], 26, FontStyle.Italic);
        }

        #endregion
    }
}
