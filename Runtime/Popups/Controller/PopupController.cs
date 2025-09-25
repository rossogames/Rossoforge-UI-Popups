using Rossoforge.UI.Popups.PopupBase;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Rossoforge.UI.Popups.Controller
{
    [RequireComponent(typeof(Animator))]
    public class PopupController : MonoBehaviour
    {
        private Animator _animator;
        private CanvasGroup _canvasGroup;
        private IPopupView _view;
        private EventSystem _eventSystem;

        private int _animationClipHash_open;
        private int _animationClipHash_close;

        public PopupState State { get; private set; }

        private async void Awake()
        {
            _animationClipHash_open = Animator.StringToHash("Open");
            _animationClipHash_close = Animator.StringToHash("Close");

            _animator = GetComponent<Animator>();
            _canvasGroup = GetComponent<CanvasGroup>();
            _canvasGroup.alpha = 0f;
            _view = GetComponent<IPopupView>();
            _eventSystem = FindAnyObjectByType<EventSystem>();

            State = PopupState.Inactive;

            await Awaitable.NextFrameAsync();
            _canvasGroup.alpha = 1f;
        }

        public void Open()
        {
            if (State == PopupState.Inactive)
            {
                _eventSystem.SetSelectedGameObject(null);
                State = PopupState.Opening;
                gameObject.SetActive(true);
                _animator.SetTrigger(_animationClipHash_open);
            }
        }
        public void Close()
        {
            if (State == PopupState.Active)
            {
                _canvasGroup.interactable = false;
                _animator.SetTrigger(_animationClipHash_close);
            }
        }

        protected virtual void OnAnimationEventOpening()
        {
            _view.OnOpening();
        }
        protected virtual void OnAnimationEventActivate()
        {
            State = PopupState.Active;
            _canvasGroup.interactable = true;
            _view.OnActivate();
        }
        protected virtual void OnAnimationEventClosing()
        {
            State = PopupState.Closing;
            _view.OnClosing();
        }
        protected virtual void OnAnimationEventDeactivate()
        {
            State = PopupState.Inactive;
            gameObject.SetActive(false);
            _view.OnDeactivate();
        }
    }
}