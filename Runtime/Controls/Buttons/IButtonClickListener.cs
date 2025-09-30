namespace Rossoforge.UI.Controls.Buttons
{
    public interface IButtonClickListener<T> where T : ButtonEventsHandler<T>
    {
        void OnClick(ButtonClickEventArg<T> eventArg);
    }
}
