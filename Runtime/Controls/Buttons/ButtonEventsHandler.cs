using UnityEngine;
using UnityEngine.UI;

namespace Rossoforge.UI.Controls.Buttons
{
    [RequireComponent(typeof(Button))]
    public abstract class ButtonEventsHandler<T> : MonoBehaviour where T : ButtonEventsHandler<T>
    {
        private Button _button;
        private IButtonClickListener<T> _clickListener;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _clickListener = GetComponentInParent<IButtonClickListener<T>>(true);
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            var eventArg = new ButtonClickEventArg<T> { Button = _button };
            _clickListener?.OnClick(eventArg);
        }
    }
}
