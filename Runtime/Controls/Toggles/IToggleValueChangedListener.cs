namespace Rossoforge.UI.Controls.Toggles
{
    public interface IToggleValueChangedListener<T>  where T: ToggleValueChangedAdapter<T>
    {
        void OnToggleValueChangedInvoked(T eventArg);
    }
}
