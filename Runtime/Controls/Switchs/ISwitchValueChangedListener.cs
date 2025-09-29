namespace Rossoforge.UI.Controls.Switchs
{
    public interface ISwitchValueChangedListener<T> where T : SwitchEventsAdapter<T>
    {
        void OnSwitchValueChangedInvoked(T eventArg);
    }
}
