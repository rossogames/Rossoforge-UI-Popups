using Rossoforge.Core.UI.Popups;
using Rossoforge.Events.Bus;

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