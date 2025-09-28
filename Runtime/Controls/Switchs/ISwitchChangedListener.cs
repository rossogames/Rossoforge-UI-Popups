namespace Rossoforge.UI.Controls.Switchs
{
    public interface ISwitchChangedListener<T>
    {
        void OnSwitchChangedInvoked(T eventArg);
    }
}
