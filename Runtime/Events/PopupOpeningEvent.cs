using Rossoforge.Events.Bus;
using Rossoforge.Popups.UI;

namespace Rossoforge.Popups.Events
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