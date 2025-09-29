namespace Rossoforge.UI.Controls.Sliders
{
    public interface ISliderValueChangedListener<T> where T : SliderEventsAdapter<T>
    {
        void OnSliderValueChangedInvoked(T eventArg);
    }
}
