using Rossoforge.Core.Events;
using Rossoforge.Core.UI;

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