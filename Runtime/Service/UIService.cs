using Rossoforge.Core.Components;
using Rossoforge.Core.Pool;
using Rossoforge.Core.Services;
using Rossoforge.Core.UI;
using UnityEngine;

namespace Rossoforge.UI.Service
{
    public class UIService: IUIService, IInitializable
    {
        private IPoolService _poolService;
        private GameObject _root;

        public UIService(IPoolService poolService)
        {
            _poolService = poolService;
        }

        public void Initialize()
        {
            _root = new GameObject("PopupsRoot");
            _root.AddComponent<DontDestroyRoot>();
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
                return popupView;
            }

            Debug.LogWarning($"Popup {popupView.name} cannot be opened. Current state: {popupView.State}");
            return null;
        }

        // OPEN WAIT UNTIL CLOSED -- 
        // POPUP CANCEL (KEYBOARD, BACK BUTTON, ETC)
        // catchear popups activos y aumentar sorting order
    }
}
