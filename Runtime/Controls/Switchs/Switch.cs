using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static Rossoforge.Extensions.RectTransformExtensions;

namespace Rossoforge.UI.Controls.Switchs
{
    public class Switch : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private SwitchImages images;
        [SerializeField] private SwitchLabels labels;
        [SerializeField] private bool _value;

        private const float margin = -10;
        private const float widgth = 86;

        public UnityEvent onSwitchChanged;

        public bool Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    UpdateToggle();
                    onSwitchChanged.Invoke();
                }
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            this.Value = !this.Value;
        }

        private void OnValidate()
        {
            UpdateToggle();
        }

        private void UpdateToggle()
        {
            var recTransform = (RectTransform)images.toggle.transform;

            images.backgroundOn.gameObject.SetActive(this.Value);
            images.backgroundOff.gameObject.SetActive(!this.Value);
            labels.labelOn.gameObject.SetActive(this.Value);
            labels.labelOff.gameObject.SetActive(!this.Value);

            if (this.Value)
            {
                recTransform.SetAnchor(RectTransformAnchorHorizontal.Right, RectTransformAnchorVertical.Middle);
                recTransform.SetRightMargin(margin);
                recTransform.SetWidth(widgth);
            }
            else
            {
                recTransform.SetAnchor(RectTransformAnchorHorizontal.Left, RectTransformAnchorVertical.Middle);
                recTransform.SetLeftMargin(margin);
                recTransform.SetWidth(widgth);
            }
        }
    }
}