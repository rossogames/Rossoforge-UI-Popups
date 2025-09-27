using Rossoforge.Core.Events;
using Rossoforge.Core.UI;
using Rossoforge.UI.Popups.Controller;

namespace Rossoforge.UI.Popups.PopupBase
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
        }
        public virtual void OnActivate()
        {
        }
        public virtual void OnHiding()
        {
        }
        public virtual void OnDeactivate()
        {
            _eventService.Raise(new PopupClosedEvent(this, View));
        }
    }
}
