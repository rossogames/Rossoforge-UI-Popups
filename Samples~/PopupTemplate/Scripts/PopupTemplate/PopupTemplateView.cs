using Rossoforge.Popups.UI;

namespace Rossoforge.Popups.Samples.PopupTemplate
{
    public class PopupTemplateView : PopupView<PopupTemplateView, PopupTemplatePresenter, PopupTemplateData>
    {
        protected override void Awake()
        {
            base.Awake();
            base.Presenter = new PopupTemplatePresenter(this);
        }
    }
}
