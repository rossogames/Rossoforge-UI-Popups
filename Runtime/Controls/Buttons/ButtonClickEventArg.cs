using UnityEngine.UI;

namespace Rossoforge.UI.Controls.Buttons
{
    public struct ButtonClickEventArg<T> where T : ButtonEventsHandler<T>
    {
        public Button Button { get; set; }
    }
}
