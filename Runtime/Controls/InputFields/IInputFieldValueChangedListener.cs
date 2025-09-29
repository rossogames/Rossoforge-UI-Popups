namespace Rossoforge.UI.Controls.InputFields
{
    public interface IInputFieldValueChangedListener<T> where T : InputFieldEventsAdapter<T>
    {
        void OnInputFieldValueChangedInvoked(T eventArg);
    }
}
