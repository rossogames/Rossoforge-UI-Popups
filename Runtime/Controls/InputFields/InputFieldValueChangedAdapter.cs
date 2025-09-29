using TMPro;
using UnityEngine;

namespace Rossoforge.UI.Controls.InputFields
{
    [RequireComponent(typeof(TMP_InputField))]
    public abstract class InputFieldValueChangedAdapter<T> : MonoBehaviour where T : InputFieldValueChangedAdapter<T>
    {
        private TMP_InputField _inputField;
        private IInputFieldValueChangedListener<T> _eventListener;
        private T _arg;

        public string Text => _inputField.text;

        private void Awake()
        {
            _inputField = GetComponent<TMP_InputField>();
            _eventListener = GetComponentInParent<IInputFieldValueChangedListener<T>>(true);
            _arg = GetComponent<T>();
        }

        private void OnEnable()
        {
            _inputField.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnDisable()
        {
            _inputField.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged(string value)
        {
            if (_eventListener != null)
                _eventListener.OnInputFieldValueChangedInvoked(_arg);
        }
    }
}
