using UnityEngine;
using UnityEngine.UI;

namespace Rossoforge.UI.Controls.Toggles
{
    [RequireComponent(typeof(Toggle))]
    public abstract class ToggleValueChangedAdapter<T> : MonoBehaviour where T : ToggleValueChangedAdapter<T>
    {
        private Toggle _toggle;
        private IToggleValueChangedListener<T> _eventListener;
        private T _arg;

        public bool IsOn => _toggle.isOn;

        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
            _eventListener = GetComponentInParent<IToggleValueChangedListener<T>>(true);
            _arg = GetComponent<T>();
        }

        private void OnEnable()
        {
            _toggle.onValueChanged.AddListener(OnToggleChanged);
        }

        private void OnDisable()
        {
            _toggle.onValueChanged.RemoveListener(OnToggleChanged);
        }

        private void OnToggleChanged(bool isOn)
        {
            if (_eventListener != null)
                _eventListener.OnToggleValueChangedInvoked(_arg);
        }
    }
}
