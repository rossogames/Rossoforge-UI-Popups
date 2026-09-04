using Rossoforge.Events.Service;
using Rossoforge.Popups.Events;
using Rossoforge.Services.Locator;

namespace Rossoforge.Popups.UI
{
    public abstract class PopupPresenter<V, P, D> : IPopupPresenter
        where V : PopupView<V, P, D>
        where P : PopupPresenter<V, P, D>
        where D : IPopupData
    {
        protected readonly IEventService _eventService;

        public bool AllowCancel { get; set; }
        protected V View { get; private set; }
        protected D Data { get; private set; }

        protected PopupPresenter(V view)
        {
            _eventService = ServiceLocator.Get<IEventService>();

            View = view;
            AllowCancel = true;
        }
        public virtual void OnDestroy()
        {
        }

        public virtual void OnSetData(D popupData)
        {
            Data = popupData;
        }

        public virtual void OnOpening()
        {
            _eventService.Raise(new PopupOpeningEvent(View));
        }
        public virtual void OnActivate()
        {
            _eventService.Raise(new PopupActivatedEvent(View));
        }
        public virtual void OnClosing()
        {
            _eventService.Raise(new PopupClosingEvent(View));
        }
        public virtual void OnDeactivate()
        {
            _eventService.Raise(new PopupDeactivatedEvent(View));
        }
    }
}
