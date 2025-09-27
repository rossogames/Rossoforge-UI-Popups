using Rossoforge.Core.Events;
using Rossoforge.Core.UI;

namespace Rossoforge.UI.Popups.Events
{
    public readonly struct PopupHidingEvent : IEvent
    {
        public readonly IPopupView PopupView;

        public PopupHidingEvent(IPopupView popupView)
        {
            PopupView = popupView;
        }
    }
}