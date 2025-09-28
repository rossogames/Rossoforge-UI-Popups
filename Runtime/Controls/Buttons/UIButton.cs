using Rossoforge.Core.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Rossoforge.UI.Controls.Buttons
{
    [RequireComponent(typeof(Button))]
    public abstract class UIButton<T> : MonoBehaviour where T : UIButton<T>
    {
        private Button _button;

        private IButtonClickListener<T> _clickListener;
        private T _arg;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _clickListener = GetComponentInParent<IButtonClickListener<T>>(true);
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
            if (_clickListener != null)
                _clickListener.OnButtonClickInvoked(_arg);
        }
    }
}
