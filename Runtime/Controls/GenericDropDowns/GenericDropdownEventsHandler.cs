using UnityEngine;

namespace Rossoforge.UI.Controls.GenericDropDowns
{
    [RequireComponent(typeof(GenericDropdown))]
    public abstract class GenericDropdownEventsHandler<T> : MonoBehaviour where T : GenericDropdownEventsHandler<T>
    {
        private GenericDropdown _dropdown;
        private IGenericDropdownSelectedItemChangedListener<T> _selectedItemChangedListener;

        private void Awake()
        {
            _dropdown = GetComponent<GenericDropdown>();
            _selectedItemChangedListener = GetComponentInParent<IGenericDropdownSelectedItemChangedListener<T>>(true);
        }

        private void OnEnable()
        {
            _dropdown.OnSelectedItemChanged.AddListener(OnSelectedItemChanged);
        }

        private void OnDisable()
        {
            _dropdown.OnSelectedItemChanged.RemoveListener(OnSelectedItemChanged);
        }

        private void OnSelectedItemChanged(object selectedItem)
        {
            var eventArgs = new GenericDropdownEventArg<T>((T)this, _dropdown.value, selectedItem);
            _selectedItemChangedListener?.OnSelectedItemChanged(eventArgs);
        }
    }
}
