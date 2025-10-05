using Rossoforge.Core.Components;
using Rossoforge.Core.Events;
using Rossoforge.Core.Pool;
using Rossoforge.Core.Services;
using Rossoforge.Core.UI;
using Rossoforge.UI.Popups.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Rossoforge.UI.Popups.Service
{
    public class UIService : IUIService, IInitializable, IDisposable,
        IEventListener<PopupDeactivatedEvent>
    {
        private IEventService _eventService;
        private IPoolService _poolService;

        private UIServiceData _serviceData;
        private GameObject _root;

        private List<IPopupView> _openPopups;
        private Dictionary<IPopupView, TaskCompletionSource<bool>> _popupCompletionSources;

        public UIService(IEventService eventService, IPoolService poolService, UIServiceData uIServiceData)
        {
            _eventService = eventService;
            _poolService = poolService;
            _serviceData = uIServiceData;

            _openPopups = new List<IPopupView>();
            _popupCompletionSources = new Dictionary<IPopupView, TaskCompletionSource<bool>>();
        }

        public void Initialize()
        {
            _root = new GameObject("PopupsRoot");
            _root.AddComponent<DontDestroyRoot>();

            _eventService.RegisterListener<PopupDeactivatedEvent>(this);
        }

        public void Dispose()
        {
            _eventService.UnregisterListener<PopupDeactivatedEvent>(this);
        }

        public void CancelPopup()
        {
            if (_openPopups.Count == 0)
                return;

            var popupView = _openPopups[^1];
            if (popupView.AllowCancel)
                popupView.Close();
        }

        public T OpenPopup<T>(IPooledGameobjectData data, IPopupData popupData = null, Vector3 position = new(), Space relativeTo = Space.Self) where T : MonoBehaviour, IPopupView
        {
            var popupView = _poolService.Get<T>(data, _root.transform, position, relativeTo);
            TryOpenPopup<T>(popupView, popupData);
            return popupView;
        }

        public async Awaitable<T> OpenPopup<T>(IPooledObjectAsyncData data, IPopupData popupData = null, Vector3 position = new(), Space relativeTo = Space.Self) where T : MonoBehaviour, IPopupView
        {
            var popupView = await _poolService.GetAsync<T>(data, _root.transform, position, relativeTo);
            TryOpenPopup<T>(popupView, popupData);
            return popupView;
        }

        public async Awaitable<T> OpenPopupUntilClosed<T>(IPooledGameobjectData data, IPopupData popupData = null, Vector3 position = new(), Space relativeTo = Space.Self) where T : MonoBehaviour, IPopupView
        {
            var tcs = new TaskCompletionSource<bool>();
            var popupView = _poolService.Get<T>(data, _root.transform, position, relativeTo);

            _popupCompletionSources.Add(popupView, tcs);
            TryOpenPopup<T>(popupView, popupData);
            await tcs.Task;

            return popupView;
        }

        public async Awaitable<T> OpenPopupUntilClosed<T>(IPooledObjectAsyncData data, IPopupData popupData = null, Vector3 position = new(), Space relativeTo = Space.Self) where T : MonoBehaviour, IPopupView
        {
            var tcs = new TaskCompletionSource<bool>();
            var popupView = await _poolService.GetAsync<T>(data, _root.transform, position, relativeTo);

            _popupCompletionSources.Add(popupView, tcs);
            TryOpenPopup<T>(popupView, popupData);
            await tcs.Task;

            return popupView;
        }

        private void TryOpenPopup<T>(T popupView, IPopupData popupData) where T : MonoBehaviour, IPopupView
        {
            if (!popupView.CanBeOpened())
            {
                Debug.LogWarning($"Popup {popupView.name} cannot be opened. Current state: {popupView.State}");
                return;
            }

            popupView.SetData(popupData);
            popupView.Open();

            _openPopups.Add(popupView);
            popupView.SetSortingOrder(_openPopups.Count + _serviceData.BaseSortingOrder);
        }

        public void OnEventInvoked(PopupDeactivatedEvent eventArg)
        {
            _openPopups.Remove(eventArg.PopupView);

            if (_popupCompletionSources.TryGetValue(eventArg.PopupView, out var tcs))
            {
                tcs.SetResult(true);
                _popupCompletionSources.Remove(eventArg.PopupView);
            }
        }
    }
}
