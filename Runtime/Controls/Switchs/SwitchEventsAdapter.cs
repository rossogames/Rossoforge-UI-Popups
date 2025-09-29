using UnityEngine;

namespace Rossoforge.UI.Controls.Switchs
{
    [RequireComponent(typeof(Switch))]
    public abstract class SwitchEventsAdapter<T> : MonoBehaviour where T : SwitchEventsAdapter<T>
    {
        private Switch _switch;
        private ISwitchValueChangedListener<T> _valueChangedListener;

        public bool IsOn => _switch.IsOn;

        private void Awake()
        {
            _switch = GetComponent<Switch>();
            _valueChangedListener = GetComponentInParent<ISwitchValueChangedListener<T>>(true);
        }

        private void OnEnable()
        {
            _switch.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnDisable()
        {
            _switch.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged(bool isOn)
        {
            _valueChangedListener?.OnSwitchValueChangedInvoked(this as T);
        }
    }
}
