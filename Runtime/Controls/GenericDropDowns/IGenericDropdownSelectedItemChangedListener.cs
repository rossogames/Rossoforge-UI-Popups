namespace Rossoforge.UI.Controls.GenericDropDowns
{
    public interface IGenericDropdownSelectedItemChangedListener<T> where T : GenericDropdownEventsHandler<T>
    {
        void OnSelectedItemChanged(T eventArg);
    }
}
