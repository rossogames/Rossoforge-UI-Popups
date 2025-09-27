using Rossoforge.Core.UI;
using Rossoforge.Pool.Data;
using Rossoforge.Services;
using Rossoforge.UI.Popups.PopupTemplate;
using UnityEngine;

namespace Rossoforge.UI.Popups.PopupDemo
{
    public class Demo : MonoBehaviour
    {
        private IUIService _uiService;

        [SerializeField]
        private PooledGameobjectData popupReference;

        private void Awake()
        {
            _uiService = ServiceLocator.Get<IUIService>();
        }

        private async void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _uiService.OpenPopup<PopupTemplateView>(popupReference);
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                Debug.LogWarning("Begin");
                await _uiService.OpenPopupUntilClosed<PopupTemplateView>(popupReference);
                Debug.LogWarning("End");
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _uiService.CancelPopup();
            }
        }
    }
}