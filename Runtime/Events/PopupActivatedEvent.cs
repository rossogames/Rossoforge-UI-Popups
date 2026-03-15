using Rossoforge.Core.Events;
using Rossoforge.Core.UI.Popups;

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