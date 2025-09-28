namespace Rossoforge.UI.Controls.Switchs
{
    public interface ISwitchValueChangedListener<T> where T : SwitchValueChangedAdapter<T>
    {
        void OnSwitchValueChangedInvoked(T eventArg);
    }
}
