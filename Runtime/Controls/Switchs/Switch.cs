using UnityEditor;
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
        [SerializeField] private bool _isOn;

        private const float margin = -10;
        private const float widgth = 86;

        public UnityEvent<bool> onValueChanged;

        public bool IsOn
        {
            get => _isOn;
            set
            {
                if (_isOn != value)
                {
                    _isOn = value;
                    UpdateToggle();
                    onValueChanged.Invoke(value);
                }
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            this.IsOn = !this.IsOn;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            EditorApplication.delayCall += () =>
            {
                if (this == null)
                    return;

                UpdateToggle();
            };
        }
#endif 

        private void UpdateToggle()
        {
            var recTransform = (RectTransform)images.toggle.transform;

            images.backgroundOn.gameObject.SetActive(this.IsOn);
            images.backgroundOff.gameObject.SetActive(!this.IsOn);
            labels.labelOn.gameObject.SetActive(this.IsOn);
            labels.labelOff.gameObject.SetActive(!this.IsOn);

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