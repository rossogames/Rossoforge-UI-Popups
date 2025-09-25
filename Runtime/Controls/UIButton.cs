using Rossoforge.Core.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Rossoforge.UI.Controls
{
    [RequireComponent(typeof(Button))]
    public abstract class UIButton<T> : MonoBehaviour
    {
        private Button _button;

        private IButtonClickListener<T> _clickListener;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _clickListener = GetComponentInParent<IButtonClickListener<T>>(true);
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            _clickListener.OnButtonClickInvoked(default);
        }
    }
}
