using Rossoforge.UI.Popups.PopupBase;

namespace Rossoforge.UI.Popups.PopupTemplate
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
