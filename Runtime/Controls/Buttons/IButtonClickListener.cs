namespace Rossoforge.UI.Controls.Buttons
{
    public interface IButtonClickListener<T> where T : ButtonEventsAdapter<T>
    {
        void OnButtonClickInvoked(T eventArg);
    }
}
