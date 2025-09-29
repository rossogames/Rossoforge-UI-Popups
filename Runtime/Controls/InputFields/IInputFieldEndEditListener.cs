namespace Rossoforge.UI.Controls.InputFields
{
    public interface IInputFieldEndEditListener<T> where T : InputFieldEventsAdapter<T>
    {
        void OnInputFieldEndEditInvoked(T arg);
    }
}