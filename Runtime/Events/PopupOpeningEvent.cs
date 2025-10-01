using Rossoforge.Core.Events;
using Rossoforge.Core.UI;

namespace Rossoforge.UI.Popups.Events
{
    public readonly struct PopupOpeningEvent : IEvent
    {
        public readonly IPopupView PopupView;

        public PopupOpeningEvent(IPopupView popupView)
        {
            PopupView = popupView;
        }
    }
}