using Rossoforge.Events.Bus;
using Rossoforge.Popups.UI;

namespace Rossoforge.Popups.Events
{
    public readonly struct PopupClosingEvent : IEvent
    {
        public readonly IPopupView PopupView;

        public PopupClosingEvent(IPopupView popupView)
        {
            PopupView = popupView;
        }
    }
}