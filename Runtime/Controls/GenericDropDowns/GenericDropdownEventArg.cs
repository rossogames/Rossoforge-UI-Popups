namespace Rossoforge.UI.Controls.GenericDropDowns
{
    public readonly struct GenericDropdownEventArg<T> where T : GenericDropdownEventsHandler<T>
    {
        public T Dropdown { get; }
        public int SelectedIndex { get; }
        public object SelectedItem { get; }

        public GenericDropdownEventArg(T dropdown, int selectedIndex, object selectedItem)
        {
            Dropdown = dropdown;
            SelectedIndex = selectedIndex;
            SelectedItem = selectedItem;
        }
    }
}
