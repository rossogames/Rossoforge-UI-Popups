namespace Rossoforge.UI.Controls.Buttons
{
    public interface IButtonClickListener<T>
    {
        void OnButtonClickInvoked(T eventArg);
    }
}
