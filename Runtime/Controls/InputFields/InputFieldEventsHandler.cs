using TMPro;
using UnityEngine;

namespace Rossoforge.UI.Controls.InputFields
{
    [RequireComponent(typeof(TMP_InputField))]
    public abstract class InputFieldEventsHandler<T> : MonoBehaviour where T : InputFieldEventsHandler<T>
    {
        private TMP_InputField _inputField;
        private IInputFieldValueChangedListener<T> _valueChangedListener;
        private IInputFieldEndEditListener<T> _endEditListener;
        private IInputFieldOnSelectListener<T> _onSelectListener;
        private IInputFieldOnDeselectListener<T> _onDeselectListener;

        public string Text => _inputField.text;
        public TMP_InputField InputField => _inputField;

        private void Awake()
        {
            _inputField = GetComponent<TMP_InputField>();
            _valueChangedListener = GetComponentInParent<IInputFieldValueChangedListener<T>>(true);
            _endEditListener = GetComponentInParent<IInputFieldEndEditListener<T>>(true);
            _onSelectListener = GetComponentInParent<IInputFieldOnSelectListener<T>>(true);
            _onDeselectListener = GetComponentInParent<IInputFieldOnDeselectListener<T>>(true);
        }

        private void OnEnable()
        {
            _inputField.onValueChanged.AddListener(OnValueChanged);
            _inputField.onEndEdit.AddListener(OnEndEdit);
            _inputField.onSelect.AddListener(OnSelect);
            _inputField.onDeselect.AddListener(OnDeselect);
        }

        private void OnDisable()
        {
            _inputField.onValueChanged.RemoveListener(OnValueChanged);
            _inputField.onEndEdit.RemoveListener(OnEndEdit);
            _inputField.onSelect.RemoveListener(OnSelect);
            _inputField.onDeselect.RemoveListener(OnDeselect);
        }

        private void OnValueChanged(string value)
        {
            _valueChangedListener?.OnValueChanged((T)this);
        }
        private void OnEndEdit(string value)
        {
            _endEditListener?.OnEndEdit((T)this);
        }
        private void OnSelect(string value)
        {
            _onSelectListener?.OnSelect((T)this);
        }
        private void OnDeselect(string value)
        {
            _onDeselectListener?.OnDeselect((T)this);
        }
    }
}
