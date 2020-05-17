#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

#endregion

namespace AVPlayerExample
{
    // Drag and Drop
    //
    // These Drag and Drop methods allow files (with certain extensions) to be dropped on the main Form (not just the player's display)
    // and added to the playlist.
    // Some of the Display Overlays pass on their Drag an Drop handling to these methods.

    public partial class Form1
    {
        // Not complete lists of audio and video extensions (and there's also image extensions and others)
        private const string    AUDIO_EXTENSIONS = ".mp3.mpeg3.wav.wma.flac.mid.midi.ogg.oga.mka.m4a.aac.wv.mpc.ac3.dts.ra.rm.opus.aif.aiff.aifc";
        private const string    VIDEO_EXTENSIONS = ".mp4.mpeg.mpeg4.mpg.avi.wmv.xvid.asf.bik.divx.dvx.f4v.flv.h264.hdmov.mkv.mod.mov.mpv.mts.ogv.qt.rm.rms.swf.vfw.vob";
        private string          _mediaExtensions = AUDIO_EXTENSIONS + VIDEO_EXTENSIONS;

        internal void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] dragFiles = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                for (int i = 0; i < dragFiles.Length; i++)
                {
                    string extension = Path.GetExtension(dragFiles[i]);
                    if (string.Equals(extension, ".lnk", StringComparison.OrdinalIgnoreCase))
                    {
                        extension = Path.GetExtension(ResolveShortcut(dragFiles[i]));
                    }
                    if (extension != "" && _mediaExtensions.IndexOf(extension, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        //e.Effect = DragDropEffects.Copy; // allow drop if there's at least one valid media file
                        e.Effect = DragDropEffects.All; // allow drop if there's at least one valid media file
                        break;
                    }
                }
            }
        }

        internal void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] dropFiles = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            List<string> newFiles = new List<string>(dropFiles.Length);

            for (int i = 0; i < dropFiles.Length; i++)
            {
                string extension = Path.GetExtension(dropFiles[i]);
                if (string.Equals(extension, ".lnk", StringComparison.OrdinalIgnoreCase))
                {
                    dropFiles[i] = ResolveShortcut(dropFiles[i]);
                    extension = Path.GetExtension(dropFiles[i]);
                }
                if (extension != "" && _mediaExtensions.IndexOf(extension, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    // collect valid media files
                    newFiles.Add(dropFiles[i]);
                }
            }

            if (newFiles.Count > 0)
            {
                // add to playlist
                int newToPlay = PlayList.Count;
                AddToPlayList(newFiles.ToArray());

                if (!Player1.Playing) // && Prefs.AutoPlayAdded)
                {
                    _mediaToPlay = newToPlay;
                    PlayNextMedia();
                }
            }
        }

        // taken from: https://blez.wordpress.com/2013/02/18/get-file-shortcuts-target-with-c/
        private string ResolveShortcut(string fileName)
        {
            //if (!String.Equals(Path.GetExtension(fileName), ".lnk", StringComparison.OrdinalIgnoreCase)) return string.Empty;
            try
            {
                FileStream fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read);
                using (BinaryReader fileReader = new BinaryReader(fileStream))
                {
                    fileStream.Seek(0x14, SeekOrigin.Begin);     // Seek to flags
                    uint flags = fileReader.ReadUInt32();        // Read flags
                    if ((flags & 1) == 1)
                    {
                        // Bit 1 set means we have to skip the shell item ID list
                        fileStream.Seek(0x4c, SeekOrigin.Begin); // Seek to the end of the header
                        uint offset = fileReader.ReadUInt16();   // Read the length of the Shell item ID list
                        fileStream.Seek(offset, SeekOrigin.Current); // Seek past it (to the file locator info)
                    }

                    long fileInfoStartsAt = fileStream.Position; // Store the offset where the file info
                    // structure begins
                    uint totalStructLength = fileReader.ReadUInt32(); // read the length of the whole struct
                    fileStream.Seek(0xc, SeekOrigin.Current); // seek to offset to base pathname
                    uint fileOffset = fileReader.ReadUInt32(); // read offset to base pathname
                    // the offset is from the beginning of the file info struct (fileInfoStartsAt)
                    fileStream.Seek((fileInfoStartsAt + fileOffset), SeekOrigin.Begin); // Seek to beginning of
                    // base pathname (target)
                    long pathLength = (totalStructLength + fileInfoStartsAt) - fileStream.Position - 2; // read
                    // the base pathname. I don't need the 2 terminating nulls.
                    char[] linkTarget = fileReader.ReadChars((int)pathLength); // should be unicode safe
                    string link = new string(linkTarget);

                    int begin = link.IndexOf("\0\0", StringComparison.Ordinal);
                    if (begin > -1)
                    {
                        int end = link.IndexOf("\\\\", begin + 2, StringComparison.Ordinal) + 2;
                        end = link.IndexOf('\0', end) + 1;

                        string firstPart = link.Substring(0, begin);
                        string secondPart = link.Substring(end);

                        return firstPart + secondPart;
                    }
                    return link;
                }
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}
