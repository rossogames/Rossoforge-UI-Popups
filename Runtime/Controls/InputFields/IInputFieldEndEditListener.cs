namespace Rossoforge.UI.Controls.InputFields
{
    internal interface IInputFieldEndEditListener<T> where T : InputFieldEndEditAdapter<T>
    {
        void OnInputFieldEndEditInvoked<T>(T arg);
    }
}