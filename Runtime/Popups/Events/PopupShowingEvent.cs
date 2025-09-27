using Rossoforge.Core.Events;
using Rossoforge.Core.UI;

namespace Rossoforge.UI.Popups.Events
{
    public readonly struct PopupShowingEvent : IEvent
    {
        public readonly IPopupView PopupView;

        public PopupShowingEvent(IPopupView popupView)
        {
            PopupView = popupView;
        }
    }
}