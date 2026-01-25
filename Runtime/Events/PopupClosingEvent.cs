using Rossoforge.Core.Events;
using Rossoforge.Core.UI.Popups;

namespace Rossoforge.UI.Popups.Events
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