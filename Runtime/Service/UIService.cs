using Rossoforge.Core.Components;
using Rossoforge.Core.Events;
using Rossoforge.Core.Pool;
using Rossoforge.Core.Services;
using Rossoforge.Core.UI;
using Rossoforge.UI.Popups.Controller;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rossoforge.UI.Service
{
    public class UIService : IUIService, IInitializable, IDisposable,
        IEventListener<PopupClosedEvent>
    {
        private IEventService _eventService;
        private IPoolService _poolService;

        private GameObject _root;
        private int _baseSortingOrder = 30000;

        private List<IPopupView> _openPopups;

        public UIService(IEventService eventService, IPoolService poolService)
        {
            _eventService = eventService;
            _poolService = poolService;
            _openPopups = new List<IPopupView>();
        }

        public void Initialize()
        {
            _root = new GameObject("PopupsRoot");
            _root.AddComponent<DontDestroyRoot>();

            _eventService.RegisterListener<PopupClosedEvent>(this);
        }

        public void Dispose()
        {
            _eventService.UnregisterListener<PopupClosedEvent>(this);
        }

        public T OpenPopup<T>(IPooledGameobjectData data, IPopupData popupData = null, Vector3 position = new(), Space relativeTo = Space.Self) where T : MonoBehaviour, IPopupView
        {
            var popupView = _poolService.Get<T>(data, _root.transform, position, relativeTo);
            return TryOpenPopup<T>(popupView, popupData);
        }

        private T TryOpenPopup<T>(T popupView, IPopupData popupData) where T : MonoBehaviour, IPopupView
        {
            if (popupView.CanBeOpened())
            {
                popupView.SetData(popupData);
                popupView.Open();

                _openPopups.Add(popupView);
                popupView.SetSortingOrder(_openPopups.Count + _baseSortingOrder);

                return popupView;
            }

            Debug.LogWarning($"Popup {popupView.name} cannot be opened. Current state: {popupView.State}");
            return null;
        }

        public void OnEventInvoked(PopupClosedEvent eventArg)
        {
            _openPopups.Remove(eventArg.PopupView);
        }

        // OPEN WAIT UNTIL CLOSED -- 
        // POPUP CANCEL (KEYBOARD, BACK BUTTON, ETC)
    }
}
