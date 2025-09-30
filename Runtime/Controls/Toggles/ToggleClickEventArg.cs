using UnityEngine.UI;

namespace Rossoforge.UI.Controls.Toggles
{
    public struct ToggleClickEventArg<T> where T : ToggleEventsHandler<T>
    {
        public Toggle Toggle { get; set; }
        public bool IsOn { get; set; }
    }
}
