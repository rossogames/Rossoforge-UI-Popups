using Rossoforge.Core.Events;
using Rossoforge.UI.Popups.Controller;

namespace Rossoforge.UI.Popups.PopupBase
{
    public abstract class PopupPresenter<V, P, D> : IPopupPresenter,
        IEventListener<PopupCancelEvent>
        where V : PopupView<V, P, D>
        where P : PopupPresenter<V, P, D>
        where D : IPopupViewData
    {
        protected readonly IEventService _eventService;

        protected bool AllowCancel { get; set; }
        protected V View { get; private set; }
        protected D Data { get; private set; }

        protected PopupPresenter(IEventService eventService, V view)
        {
            _eventService = eventService;

            View = view;
            AllowCancel = true;
        }

        public virtual void OnSetData(D popupData)
        {
            Data = popupData;
        }

        public virtual void OnShowing()
        {
            _eventService.RegisterListener<PopupCancelEvent>(this);
        }
        public virtual void OnActivate()
        {
        }
        public virtual void OnHiding()
        {
            _eventService.UnregisterListener<PopupCancelEvent>(this);
        }
        public virtual void OnDeactivate()
        {
            _eventService.Raise(new PopupClosedEvent(this, View));
        }

        public virtual void OnEventInvoked(PopupCancelEvent eventArg)
        {
            if (AllowCancel)
                View.Close();
        }
    }
}
