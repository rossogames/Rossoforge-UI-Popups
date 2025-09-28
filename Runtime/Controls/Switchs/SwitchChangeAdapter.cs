using UnityEngine;

namespace Rossoforge.UI.Controls.Switchs
{
    [RequireComponent(typeof(Switch))]
    public abstract class SwitchChangeAdapter<T> : MonoBehaviour where T : SwitchChangeAdapter<T>
    {
        private Switch _switch;
        private ISwitchChangedListener<T> _eventListener;
        private T _arg;

        public bool Value => _switch.Value;

        private void Awake()
        {
            _switch = GetComponent<Switch>();
            _eventListener = GetComponentInParent<ISwitchChangedListener<T>>(true);
            _arg = GetComponent<T>();
        }

        private void OnEnable()
        {
            _switch.onSwitchChanged.AddListener(OnSwitchChanged);
        }

        private void OnDisable()
        {
            _switch.onSwitchChanged.RemoveListener(OnSwitchChanged);
        }

        private void OnSwitchChanged()
        {
            if (_eventListener != null)
                _eventListener.OnSwitchChangedInvoked(_arg);
        }
    }
}
