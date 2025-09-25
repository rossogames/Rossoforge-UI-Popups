namespace Rossoforge.UI.Popups.PopupBase
{
    public interface IPopupView
    {
        PopupState State { get; }

        void SetData(IPopupData popupData);
        void Close();
        void Open();

        void OnOpening();
        void OnActivate();
        void OnClosing();
        void OnDeactivate();
    }
}
