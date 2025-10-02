using Rossoforge.UI.Controls.Buttons;
using Rossoforge.UI.Popups.PopupBase;
using TMPro;
using UnityEngine;

namespace Rossoforge.UI.Popups.PopupQuestion
{
    public class PopupQuestionView : PopupView<PopupQuestionView, PopupQuestionPresenter, PopupQuestionData>,
        IButtonClickListener<PopupQuestionButtonOk>,
        IButtonClickListener<PopupQuestionButtonCancel>
    {
        [SerializeField]
        private TextMeshProUGUI _labelTitle;

        [SerializeField]
        private TextMeshProUGUI _labelMessage;

        protected override void Awake()
        {
            base.Awake();
            base.Presenter = new PopupQuestionPresenter(this);
        }

        public void SetMessageText(string text)
        {
            _labelMessage.text = text;
        }

        public void SetTitleText(string text)
        {
            _labelTitle.text = text;
        }

        public void OnClick(ButtonEventArg<PopupQuestionButtonOk> eventArg)
        {
            Presenter.Confirm();
        }

        public void OnClick(ButtonEventArg<PopupQuestionButtonCancel> eventArg)
        {
            Close();
        }
    }
}
