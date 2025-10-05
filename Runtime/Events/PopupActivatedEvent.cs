using Rossoforge.Core.Events;
using Rossoforge.Core.UI;

namespace Rossoforge.UI.Popups.Events
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