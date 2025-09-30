using UnityEngine.UI;

namespace Rossoforge.UI.Controls.Toggles
{
    public readonly struct ToggleEventArg<T> where T : ToggleEventsHandler<T>
    {
        public Toggle Toggle { get; }
        public bool IsOn { get; }

        public ToggleEventArg(Toggle toggle, bool isOn)
        {
            Toggle = toggle;
            IsOn = isOn;
        }
    }
}
