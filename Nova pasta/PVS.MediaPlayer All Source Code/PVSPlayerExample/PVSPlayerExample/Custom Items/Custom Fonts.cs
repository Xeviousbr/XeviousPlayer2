#region Usings

using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Reflection;

#endregion

namespace PVSPlayerExample
{
    public partial class MainWindow
    {
        // ******************************** Install Custom Fonts

        #region Install Custom Fonts

        private void InstallCustomFonts()
        {
            if (FontCollection != null) return; // return if already installed
            //or: throw new InvalidOperationException("Custom fonts already installed.");

            string[] customFonts = { "PVSPlayerExample.Resources.Crystal Italic1.ttf", "PVSPlayerExample.Resources.WingDings3a.ttf" };
            Assembly assembly = GetType().Assembly;
            Stream   fontStream;
            byte[]   fontData;

            // create private fontcollection for custom fonts
            FontCollection = new PrivateFontCollection();

            // add custom fonts to private fontcollection
            for (int i = 0; i < customFonts.Length; i++)
            {
                fontStream = assembly.GetManifestResourceStream(customFonts[i]);
                fontData = new byte[fontStream.Length];
                fontStream.Read(fontData, 0, (int)fontStream.Length);
                fontStream.Close();
                unsafe
                {
                    fixed (byte* pFontData = fontData)
                    {
                        uint pcFonts = 0;
                        FontCollection.AddMemoryFont((IntPtr)pFontData, fontData.Length);
                        SafeNativeMethods.AddFontMemResourceEx((IntPtr)pFontData, (uint)fontData.Length, IntPtr.Zero, ref pcFonts);
                    }
                }
            }

            // create fonts (could have been done anywhere else, as with 'normal' fonts)
            _crystalFont16 = new Font(FontCollection.Families[0], 16, FontStyle.Italic); // or new Font("Crystal", 16, FontStyle.Italic);
            _clockFont25 = new Font(FontCollection.Families[0], 25, FontStyle.Italic);   // or new Font("Crystal", 25, FontStyle.Italic);
            _wingDng38 = new Font(FontCollection.Families[1], 8, FontStyle.Regular);     // or new Font("WingDings 3", 8, FontStyle.Regular);
        }

        #endregion
    }
}
