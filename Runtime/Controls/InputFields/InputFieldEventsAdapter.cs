using TMPro;
using UnityEngine;

namespace Rossoforge.UI.Controls.InputFields
{
    [RequireComponent(typeof(TMP_InputField))]
    public abstract class InputFieldEventsAdapter<T> : MonoBehaviour where T : InputFieldEventsAdapter<T>
    {
        private TMP_InputField _inputField;
        private IInputFieldValueChangedListener<T> _valueChangedListener;
        private IInputFieldEndEditListener<T> _endEditListener;
        private T _arg;

        public string Text => _inputField.text;

        private void Awake()
        {
            _inputField = GetComponent<TMP_InputField>();
            _valueChangedListener = GetComponentInParent<IInputFieldValueChangedListener<T>>(true);
            _endEditListener = GetComponentInParent<IInputFieldEndEditListener<T>>(true);
            _arg = GetComponent<T>();
        }

        private void OnEnable()
        {
            _inputField.onValueChanged.AddListener(OnValueChanged);
            _inputField.onEndEdit.AddListener(OnEndEdit);
        }

        private void OnDisable()
        {
            _inputField.onValueChanged.RemoveListener(OnValueChanged);
            _inputField.onEndEdit.RemoveListener(OnEndEdit);
        }

        private void OnValueChanged(string value)
        {
            _valueChangedListener?.OnInputFieldValueChangedInvoked(_arg);
        }
        private void OnEndEdit(string value)
        {
            _endEditListener?.OnInputFieldEndEditInvoked(_arg);
        }
    }
}
