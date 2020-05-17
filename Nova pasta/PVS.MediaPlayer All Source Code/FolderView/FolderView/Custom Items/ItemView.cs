#region Usings

using PVS.MediaPlayer;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace FolderView
{
    public partial class ItemView : UserControl
    {
        internal MainWindow ItemParent;
        internal Player     ItemPlayer;

        public ItemView()
        {
            InitializeComponent();
        }

        // Set focus back to flowLayoutPanel1 on main form (for mousewheel scroll)
        private void CustomSlider1_MouseUp(object sender, MouseEventArgs e)
        {
            base.Parent.Focus();
        }

        // Show infolabel
        private void CustomSlider1_Scroll(object sender, System.EventArgs e)
        {
            if (ModifierKeys == Keys.Shift) // don't show with shift key pressed
            {
                ItemParent.ItemViewLabel.Hide(true);
            }
            else
            {
                // Get the position slider's x-coordinate of the current position (= thumb location)
                // (AlignmentOffset has been set to 0, 2)
                Point infoLabelLocation = SliderValue.ToPoint(customSlider1, customSlider1.Value);

                // Show the infolabel
                ItemParent.ItemViewLabel.Show(ItemPlayer.Position.FromStart.ToString().Substring(0, 8), customSlider1, infoLabelLocation);
            }
        }
    }
}
