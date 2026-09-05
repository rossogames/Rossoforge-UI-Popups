using Rossoforge.Events.Bus;
using Rossoforge.Popups.UI;

namespace Rossoforge.Popups.Events
{
    public readonly struct PopupDeactivatedEvent : IEvent
    {
        public readonly IPopupView PopupView;

        public PopupDeactivatedEvent(IPopupView popupView)
        {
            PopupView = popupView;
        }
    }
}