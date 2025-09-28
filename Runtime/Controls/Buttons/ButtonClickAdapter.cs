using UnityEngine;
using UnityEngine.UI;

namespace Rossoforge.UI.Controls.Buttons
{
    [RequireComponent(typeof(Button))]
    public abstract class ButtonClickAdapter<T> : MonoBehaviour where T : ButtonClickAdapter<T>
    {
        private Button _button;
        private IButtonClickListener<T> _eventListener;
        private T _arg;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _eventListener = GetComponentInParent<IButtonClickListener<T>>(true);
            _arg = GetComponent<T>();
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
            if (_eventListener != null)
                _eventListener.OnButtonClickInvoked(_arg);
        }
    }
}
