using Rossoforge.Core.Events;
using Rossoforge.Services;
using Rossoforge.UI.Popups.PopupBase;

namespace Rossoforge.UI.Popups.PopupTemplate
{
    public class PopupTemplatePresenter : PopupPresenter<PopupTemplateView, PopupTemplatePresenter, PopupTemplateData>
    {
        public PopupTemplatePresenter(PopupTemplateView view)
            : base(ServiceLocator.Get<IEventService>(), view)
        {
        }
    }
}
