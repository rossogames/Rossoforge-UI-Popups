using Rossoforge.Core.UI;

namespace Rossoforge.UI.Popups.PopupQuestion
{
    public class PopupQuestionData : IPopupData
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string ConfirmButtonText { get; set; }
        public string CancelButtonText { get; set; }
        public QuestionResult Result { get; set; }
    }

    public enum QuestionResult
    {
        Cancel,
        Ok,
    }
}
