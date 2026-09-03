using Rossoforge.Core.UI.Popups;
using Rossoforge.Events.Bus;

namespace Rossoforge.UI.Popups.Events
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