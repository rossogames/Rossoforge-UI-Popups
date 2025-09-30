namespace Rossoforge.UI.Controls.InputFields
{
    public interface IInputFieldValueChangedListener<T> where T : InputFieldEventsHandler<T>
    {
        void OnValueChanged(T eventArg);
    }
    public interface IInputFieldOnSelectListener<T> where T : InputFieldEventsHandler<T>
    {
        void OnSelect(T eventArg);
    }
    public interface IInputFieldOnDeselectListener<T> where T : InputFieldEventsHandler<T>
    {
        void OnDeselect(T eventArg);
    }
}
