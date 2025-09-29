namespace Rossoforge.UI.Controls.Toggles
{
    public interface IToggleValueChangedListener<T>  where T: ToggleEventsAdapter<T>
    {
        void OnToggleValueChangedInvoked(T eventArg);
    }
}
