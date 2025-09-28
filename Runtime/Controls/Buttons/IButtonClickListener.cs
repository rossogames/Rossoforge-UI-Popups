namespace Rossoforge.UI.Controls.Buttons
{
    public interface IButtonClickListener<T> where T : ButtonClickAdapter<T>
    {
        void OnButtonClickInvoked(T eventArg);
    }
}
