namespace Rossoforge.UI.Controls.Toggles
{
    public interface IToggleValueChangedListener<T>  where T: ToggleEventsHandler<T>
    {
        void OnValueChanged(ToggleClickEventArg<T> eventArg);
    }
}
