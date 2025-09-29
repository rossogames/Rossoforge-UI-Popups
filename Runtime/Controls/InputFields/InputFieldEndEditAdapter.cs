using TMPro;
using UnityEngine;

namespace Rossoforge.UI.Controls.InputFields
{
    [RequireComponent(typeof(TMP_InputField))]
    public abstract class InputFieldEndEditAdapter<T> : MonoBehaviour where T : InputFieldEndEditAdapter<T>
    {
        private TMP_InputField _inputField;
        private IInputFieldEndEditListener<T> _eventListener;
        private T _arg;

        public string Text => _inputField.text;

        private void Awake()
        {
            _inputField = GetComponent<TMP_InputField>();
            _eventListener = GetComponentInParent<IInputFieldEndEditListener<T>>(true);
            _arg = GetComponent<T>();
        }

        private void OnEnable()
        {
            _inputField.onEndEdit.AddListener(OnValueChanged);
        }

        private void OnDisable()
        {
            _inputField.onEndEdit.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged(string value)
        {
            if (_eventListener != null)
                _eventListener.OnInputFieldEndEditInvoked(_arg);
        }
    }
}
