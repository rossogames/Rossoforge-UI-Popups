using Rossoforge.Events.Bus;
using Rossoforge.Popups.UI;

namespace Rossoforge.Popups.Events
{
    public readonly struct PopupActivatedEvent : IEvent
    {
        public readonly IPopupView PopupView;

        public PopupActivatedEvent(IPopupView popupView)
        {
            PopupView = popupView;
        }
    }
}