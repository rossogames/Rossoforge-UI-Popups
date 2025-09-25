using Rossoforge.Core.Pool;
using Rossoforge.Core.UI;
using UnityEngine;

namespace Rossoforge.UI.Service
{
    public class UIService: IUIService
    {
        private IPoolService _poolService;

        public UIService(IPoolService poolService)
        {
            _poolService = poolService;
        }

        public T OpenPopup<T>(IPooledGameobjectData data, Vector3 position = new(), Space relativeTo = Space.Self) where T : MonoBehaviour, IPopupView
        {
            //Transform parent,
            var popupView = _poolService.Get<T>(data, null, position, relativeTo);

            if (popupView.CanBeOpened())
            {
                popupView.Open();
                return popupView;
            }
            
            Debug.LogWarning($"Popup {popupView.name} cannot be opened. Current state: {popupView.State}");
            return null;

            
        }

        // CREAR ROOT DE POPUPS (CANVAS) // quizas mejor dejarlos en el root
        // OPEN WAIT UNTIL CLOSED -- 
        // POPUP CANCEL (KEYBOARD, BACK BUTTON, ETC)
    }
}
