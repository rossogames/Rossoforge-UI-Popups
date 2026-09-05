using Rossoforge.Events.Bus;
using Rossoforge.Events.Service;
using Rossoforge.Pool.DataConfig;
using Rossoforge.Popups.Events;
using Rossoforge.Popups.Samples.PopupTemplate;
using Rossoforge.Popups.Service;
using Rossoforge.Services.Locator;
using UnityEngine;

namespace Rossoforge.Popups.Samples.PopupDemo
{
    public class Demo : MonoBehaviour,
        IEventListener<PopupOpeningEvent>,
        IEventListener<PopupActivatedEvent>,
        IEventListener<PopupClosingEvent>,
        IEventListener<PopupDeactivatedEvent>
    {
        private IEventService _eventService;
        private IPopupService _popupService;

        [SerializeField]
        private PooledGameobjectDataConfig popupReference;

        private void Awake()
        {
            _eventService = ServiceLocator.Get<IEventService>();
            _popupService = ServiceLocator.Get<IPopupService>();
        }

        private void OnEnable()
        {
            _eventService.RegisterListener<PopupOpeningEvent>(this);
            _eventService.RegisterListener<PopupActivatedEvent>(this);
            _eventService.RegisterListener<PopupClosingEvent>(this);
            _eventService.RegisterListener<PopupDeactivatedEvent>(this);
        }

        private void OnDisable()
        {
            _eventService.UnregisterListener<PopupOpeningEvent>(this);
            _eventService.UnregisterListener<PopupActivatedEvent>(this);
            _eventService.UnregisterListener<PopupClosingEvent>(this);
            _eventService.UnregisterListener<PopupDeactivatedEvent>(this);
        }

        private async void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _popupService.OpenPopup<PopupTemplateView>(popupReference);
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.LogWarning("Begin");
                await _popupService.OpenPopupUntilClosed<PopupTemplateView>(popupReference);
                Debug.LogWarning("End");
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _popupService.CancelPopup();
            }
        }

        public void OnEventInvoked(PopupOpeningEvent eventArg)
        {
            // This event is invoked before the popup is actually opened
            Debug.LogWarning($"Popup opened - {eventArg.PopupView.Name}");
        }

        public void OnEventInvoked(PopupActivatedEvent eventArg)
        {
            // This event is invoked after the popup is actually opened
            Debug.LogWarning($"Popup activated - {eventArg.PopupView.Name}");
        }

        public void OnEventInvoked(PopupClosingEvent eventArg)
        {
            // This event is invoked before the popup is actually closed
            Debug.LogWarning($"Popup closing - {eventArg.PopupView.Name}");
        }

        public void OnEventInvoked(PopupDeactivatedEvent eventArg)
        {
            // This event is invoked after the popup is actually closed
            Debug.LogWarning($"Popup deactivated - {eventArg.PopupView.Name}");
        }
    }
}