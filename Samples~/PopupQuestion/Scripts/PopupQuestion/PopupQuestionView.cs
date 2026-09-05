using Rossoforge.Controls.Buttons;
using Rossoforge.Popups.UI;
using TMPro;
using UnityEngine;

namespace Rossoforge.Popups.Samples.PopupQuestion
{
    public class PopupQuestionView : PopupView<PopupQuestionView, PopupQuestionPresenter, PopupQuestionData>,
        IButtonClickListener<PopupQuestionButtonOk>,
        IButtonClickListener<PopupQuestionButtonCancel>
    {
        [SerializeField]
        private TextMeshProUGUI _labelTitle;

        [SerializeField]
        private TextMeshProUGUI _labelMessage;

        [SerializeField]
        private TextMeshProUGUI _labelButtonConfirm;

        [SerializeField]
        private TextMeshProUGUI _labelButtonCancel;

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

        public void SetConfirmButtonText(string text)
        {
            _labelButtonConfirm.text = text;
        }

        public void SetCancelButtonText(string text)
        {
            _labelButtonCancel.text = text;
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
