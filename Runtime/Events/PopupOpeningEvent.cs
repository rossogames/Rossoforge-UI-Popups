using Rossoforge.Core.UI.Popups;
using Rossoforge.Events.Bus;

namespace Rossoforge.UI.Popups.Events
{
    public readonly struct PopupOpeningEvent : IEvent
    {
        public readonly IPopupView PopupView;

        public PopupOpeningEvent(IPopupView popupView)
        {
            PopupView = popupView;
        }
    }
}