namespace Rossoforge.UI.Controls.Sliders
{
    public interface ISliderValueChangedListener<T> where T : SliderValueChangedAdapter<T>
    {
        void OnSliderValueChangedInvoked(T eventArg);
    }
}
