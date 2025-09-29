using UnityEngine;
using UnityEngine.UI;

namespace Rossoforge.UI.Controls.Sliders
{
    [RequireComponent(typeof(Slider))]
    public abstract class SliderValueChangedAdapter<T> : MonoBehaviour where T : SliderValueChangedAdapter<T>
    {
        private Slider _slider;
        private ISliderValueChangedListener<T> _eventListener;
        private T _arg;

        public float Value => _slider.value;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _eventListener = GetComponentInParent<ISliderValueChangedListener<T>>(true);
            _arg = GetComponent<T>();
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
            if (_eventListener != null)
                _eventListener.OnSliderValueChangedInvoked(_arg);
        }
    }
}
