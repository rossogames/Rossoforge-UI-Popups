using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

namespace Rossoforge.UI.Controls.Dropdowns
{
    public class GenericDropdown : TMP_Dropdown
    {
        private List<object> items = new();

        [SerializeField] private string _textMember;

        public string TextMember
        {
            get => _textMember;
            set => _textMember = value;
        }

        public void AddItem<T>(T item)
        {
            items.Add(item);
            options.Add(new OptionData(GetItemText(item)));
            RefreshShownValue();
        }

        public void AddItems<T>(IEnumerable<T> newItems)
        {
            foreach (var item in newItems)
            {
                items.Add(item);
                options.Add(new OptionData(GetItemText(item)));
            }
            RefreshShownValue();
        }

        public T GetSelectedItem<T>()
        {
            if (value < 0 || value >= items.Count)
                return default;

            return (T)items[value];
        }

        private string GetItemText(object item)
        {
            if (item == null)
                return "<null>";

            if (string.IsNullOrEmpty(TextMember))
                return item.ToString();

            var type = item.GetType();

            var prop = type.GetProperty(TextMember, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null)
            {
                var val = prop.GetValue(item);
                return val?.ToString() ?? "<null>";
            }

            var field = type.GetField(TextMember, BindingFlags.Public | BindingFlags.Instance);
            if (field != null)
            {
                var val = field.GetValue(item);
                return val?.ToString() ?? "<null>";
            }

            Debug.LogWarning($"Property '{TextMember}' not found in type {item.GetType().Name}. Fallback to ToString().");
            return item.ToString();
        }
    }
}
