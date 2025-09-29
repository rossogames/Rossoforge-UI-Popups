namespace Rossoforge.UI.Controls.Toggles
{
    public interface IToggleValueChangedListener<T>  where T: ToggleEventsHandler<T>
    {
        void OnValueChanged(T eventArg);
    }
}
