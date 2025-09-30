using UnityEngine.UI;

namespace Rossoforge.UI.Controls.Buttons
{
    public readonly struct ButtonEventArg<T> where T : ButtonEventsHandler<T>
    {
        public Button Button { get; }

        public ButtonEventArg(Button button)
        {
            Button = button;
        }
    }
}
