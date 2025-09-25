namespace Rossoforge.UI.Controls
{
    public interface IButtonClickListener<T>
    {
        void OnButtonClickInvoked(T eventArg);
    }
}
