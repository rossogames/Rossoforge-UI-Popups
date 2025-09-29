using UnityEngine;
using UnityEngine.UI;

namespace Rossoforge.UI.Controls.Toggles
{
    [RequireComponent(typeof(Toggle))]
    public abstract class ToggleEventsAdapter<T> : MonoBehaviour where T : ToggleEventsAdapter<T>
    {
        private Toggle _toggle;
        private IToggleValueChangedListener<T> _valueChangedListener;

        public bool IsOn => _toggle.isOn;

        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
            _valueChangedListener = GetComponentInParent<IToggleValueChangedListener<T>>(true);
        }

        private void OnEnable()
        {
            _toggle.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnDisable()
        {
            _toggle.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged(bool isOn)
        {
            _valueChangedListener?.OnToggleValueChangedInvoked(this as T);
        }
    }
}
