using UnityEngine;

namespace Rossoforge.UI.Controls.Switchs
{
    [RequireComponent(typeof(Switch))]
    public abstract class SwitchValueChangedAdapter<T> : MonoBehaviour where T : SwitchValueChangedAdapter<T>
    {
        private Switch _switch;
        private ISwitchValueChangedListener<T> _eventListener;
        private T _arg;

        public bool IsOn => _switch.IsOn;

        private void Awake()
        {
            _switch = GetComponent<Switch>();
            _eventListener = GetComponentInParent<ISwitchValueChangedListener<T>>(true);
            _arg = GetComponent<T>();
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
            if (_eventListener != null)
                _eventListener.OnSwitchValueChangedInvoked(_arg);
        }
    }
}
