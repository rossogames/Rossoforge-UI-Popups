namespace Rossoforge.UI.Controls.InputFields
{
    public interface IInputFieldValueChangedListener<T> where T : InputFieldValueChangedAdapter<T>
    {
        void OnInputFieldValueChangedInvoked(T eventArg);
    }
}
