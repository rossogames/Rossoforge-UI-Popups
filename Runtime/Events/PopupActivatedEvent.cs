using Rossoforge.Core.UI.Popups;
using Rossoforge.Events.Bus;

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