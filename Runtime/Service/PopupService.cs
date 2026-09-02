using Rossoforge.Core.Components;
using Rossoforge.Core.Events;
using Rossoforge.Core.Pool;
using Rossoforge.Core.Services;
using Rossoforge.Core.UI.Popups;
using Rossoforge.Services;
using Rossoforge.UI.Popups.Events;
using Rossoforge.Utils.Logger;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Rossoforge.UI.Popups.Service
{
    public class PopupService : IPopupService, IInitializable, IDisposable,
        IEventListener<PopupDeactivatedEvent>
    {
        private IEventService _eventService;
        private IPoolService _poolService;

        private PopupServiceData _serviceData;
        private GameObject _root;

        private readonly List<IPopupView> _openPopups;
        private readonly Dictionary<IPopupView, TaskCompletionSource<bool>> _popupCompletionSources;

        public PopupService(PopupServiceData popupServiceData)
        {
            _serviceData = popupServiceData;

            _openPopups = new List<IPopupView>();
            _popupCompletionSources = new Dictionary<IPopupView, TaskCompletionSource<bool>>();
        }

        public void Initialize()
        {
            _eventService = ServiceLocator.Get<IEventService>();
            _poolService = ServiceLocator.Get<IPoolService>();

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

        public T OpenPopup<T>(IPooledGameobjectData data, IPopupData popupData = null, Vector3 position = new(), Space relativeTo = Space.Self, string poolCategory = IPoolService.DEFAULT_CATEGORY) where T : MonoBehaviour, IPopupView
        {
            var popupView = _poolService.Get<T>(data, _root.transform, position, relativeTo, poolCategory);
            TryOpenPopup<T>(popupView, popupData);
            return popupView;
        }
        public async Awaitable<T> OpenPopupUntilClosed<T>(IPooledGameobjectData data, IPopupData popupData = null, Vector3 position = new(), Space relativeTo = Space.Self, string poolCategory = IPoolService.DEFAULT_CATEGORY) where T : MonoBehaviour, IPopupView
        {
            var tcs = new TaskCompletionSource<bool>();
            var popupView = _poolService.Get<T>(data, _root.transform, position, relativeTo, poolCategory);

            _popupCompletionSources.Add(popupView, tcs);
            TryOpenPopup<T>(popupView, popupData);
            await tcs.Task;

            return popupView;

        }
#if HAS_ADDRESSABLES
        public async Awaitable<T> OpenPopup<T>(IPooledObjectAsyncData data, IPopupData popupData = null, Vector3 position = new(), Space relativeTo = Space.Self, string poolCategory = IPoolService.DEFAULT_CATEGORY) where T : MonoBehaviour, IPopupView
        {
            var popupView = await _poolService.GetAsync<T>(data, _root.transform, position, relativeTo, poolCategory);
            TryOpenPopup<T>(popupView, popupData);
            return popupView;
        }
        public async Awaitable<T> OpenPopupUntilClosed<T>(IPooledObjectAsyncData data, IPopupData popupData = null, Vector3 position = new(), Space relativeTo = Space.Self, string poolCategory = IPoolService.DEFAULT_CATEGORY) where T : MonoBehaviour, IPopupView
        {
            var tcs = new TaskCompletionSource<bool>();
            var popupView = await _poolService.GetAsync<T>(data, _root.transform, position, relativeTo, poolCategory);

            _popupCompletionSources.Add(popupView, tcs);
            TryOpenPopup<T>(popupView, popupData);
            await tcs.Task;

            return popupView;
        }
#endif

        private void TryOpenPopup<T>(T popupView, IPopupData popupData) where T : MonoBehaviour, IPopupView
        {
            if (!popupView.CanBeOpened())
            {
                RossoLogger.Warning($"Popup {popupView.name} cannot be opened. Current state: {popupView.State}");
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
