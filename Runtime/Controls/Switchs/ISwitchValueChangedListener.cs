namespace Rossoforge.UI.Controls.Switchs
{
    public interface ISwitchValueChangedListener<T> where T : SwitchEventsHandler<T>
    {
        void OnValueChanged(T eventArg);
    }
}
