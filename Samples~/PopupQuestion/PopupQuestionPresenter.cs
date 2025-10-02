using Rossoforge.Core.Events;
using Rossoforge.Services;
using Rossoforge.UI.Popups.PopupBase;

namespace Rossoforge.UI.Popups.PopupQuestion
{
    public class PopupQuestionPresenter : PopupPresenter<PopupQuestionView, PopupQuestionPresenter, PopupQuestionData>
    {
        public PopupQuestionPresenter(PopupQuestionView view)
            : base(ServiceLocator.Get<IEventService>(), view)
        {
        }

        public override void OnOpening()
        {
            base.OnOpening();

            Data.Result = QuestionResult.Cancel;
            View.SetTitleText(Data.Title);
            View.SetMessageText(Data.Message);
        }

        public void Confirm()
        {
            Data.Result = QuestionResult.Ok;
            View.Close();
        }
    }
}
