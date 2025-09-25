namespace Rossoforge.UI.Buttons
{
    public interface IButtonClickListener<T>
    {
        void OnButtonClickInvoked(T eventArg);
    }
}
