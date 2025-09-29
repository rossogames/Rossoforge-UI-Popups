using UnityEngine;
using UnityEngine.UI;

namespace Rossoforge.UI.Controls.Sliders
{
    [RequireComponent(typeof(Slider))]
    public abstract class SliderEventsAdapter<T> : MonoBehaviour where T : SliderEventsAdapter<T>
    {
        private Slider _slider;
        private ISliderValueChangedListener<T> _valueChangedListener;

        public float Value => _slider.value;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _valueChangedListener = GetComponentInParent<ISliderValueChangedListener<T>>(true);
        }

        private void OnEnable()
        {
            _slider.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged(float value)
        {
            _valueChangedListener?.OnSliderValueChangedInvoked(this as T);
        }
    }
}
