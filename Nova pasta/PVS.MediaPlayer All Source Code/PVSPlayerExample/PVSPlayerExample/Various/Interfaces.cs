namespace PVSPlayerExample
{

    // ******************************** Interfaces

    // ******************************** IOverlay

    #region IOverlay

    // Interface used with overlays for easy access (overlay menu setting)
    // and main player MediaStopped notification

    internal interface IOverlay
    {
        bool HasMenu
        {
            get;
        }

        bool MenuEnabled
        {
            get;
            set;
        }

        void MediaStopped();
    }

    #endregion
}
