using Rossoforge.Popups.UI;

namespace Rossoforge.Popups.Samples.PopupQuestion
{
    public class PopupQuestionPresenter : PopupPresenter<PopupQuestionView, PopupQuestionPresenter, PopupQuestionData>
    {
        public PopupQuestionPresenter(PopupQuestionView view) : base(view)
        {
        }

        public override void OnOpening()
        {
            base.OnOpening();

            Data.Result = QuestionResult.Cancel;
            View.SetTitleText(Data.Title);
            View.SetMessageText(Data.Message);
            View.SetConfirmButtonText(Data.ConfirmButtonText);
            View.SetCancelButtonText(Data.CancelButtonText);
        }

        public void Confirm()
        {
            Data.Result = QuestionResult.Ok;
            View.Close();
        }
    }
}
