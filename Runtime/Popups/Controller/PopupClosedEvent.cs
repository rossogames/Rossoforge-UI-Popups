using Rossoforge.Core.Events;
using Rossoforge.UI.Popups.PopupBase;

namespace Rossoforge.UI.Popups.Controller
{
    public readonly struct PopupClosedEvent : IEvent
    {
        public readonly IPopupPresenter PopupPresenter;
        public readonly IPopupView PopupView;

        public PopupClosedEvent(IPopupPresenter popupPresenter, IPopupView popupView)
        {
            PopupPresenter = popupPresenter;
            PopupView = popupView;
        }
    }
}