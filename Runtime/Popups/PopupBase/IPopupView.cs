namespace Rossoforge.UI.Popups.PopupBase
{
    public interface IPopupView
    {
        PopupState State { get; }

        void SetData(IPopupViewData popupData);
        bool CanBeOpened();
        bool CanBeClosed();
        void Close();
        void Open();

        void OnOpening();
        void OnActivate();
        void OnClosing();
        void OnDeactivate();
    }
}
