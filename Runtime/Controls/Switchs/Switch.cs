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
        [SerializeField] private bool isOn;

        public UnityEvent onSwitchChanged;

        public bool IsOn
        {
            get => isOn;
            set
            {
                if (isOn != value)
                {
                    isOn = value;
                    UpdateToggle();
                    onSwitchChanged.Invoke();
                }
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            this.IsOn = !this.IsOn;
        }

        private void OnValidate()
        {
            UpdateToggle();
        }

        private void UpdateToggle()
        {
            var recTransform = (RectTransform)images.toggle.transform;

            images.backgroundOn.gameObject.SetActive(this.IsOn);
            images.backgroundOff.gameObject.SetActive(!this.IsOn);
            labels.labelOn.gameObject.SetActive(this.IsOn);
            labels.labelOff.gameObject.SetActive(!this.IsOn);

            float margin = -10;
            float widgth = 86;
            if (this.IsOn)
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