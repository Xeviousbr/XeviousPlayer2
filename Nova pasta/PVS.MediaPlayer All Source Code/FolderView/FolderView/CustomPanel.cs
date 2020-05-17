using System.Windows.Forms;

namespace FolderView
{
    // double buffered panel for peak meter with lineargradient brush
    class CustomPanel : Panel
    {
        public CustomPanel()
        {
            DoubleBuffered = true;
        }
    }
}
