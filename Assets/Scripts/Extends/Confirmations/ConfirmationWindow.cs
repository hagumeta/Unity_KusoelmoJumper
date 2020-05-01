using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Extends.Confirmations
{
    public class ConfirmationWindow : MonoBehaviour
    {
        [SerializeField] private UnityEvent windowOpenEvent;
        [SerializeField] private UnityEvent windowCloseEvent;
        [SerializeField] private float windowCloseTime;
        [SerializeField] private float windowOpenTime;
        [SerializeField] private TMPro.TMP_Text questionText;
        public delegate void ConfirmCallback(Choise choise);

        private ConfirmCallback callback;
        private bool isWaiting;
        private Choise choise;
        private string question;

        private IEnumerator Start()
        {
            this.isWaiting = false;
            if (this.questionText != null && this.question != null)
            {
                this.questionText.text = this.question;
            }
            this.windowOpenEvent.Invoke();
            yield return new WaitForSecondsRealtime(this.windowOpenTime);
            this.isWaiting = true;
        }

        public void Yes()
        {
            this.ReceiveAnswer(Choise.yes);
        }

        public void No()
        {
            this.ReceiveAnswer(Choise.no);
        }

        protected void ReceiveAnswer(Choise choise)
        {
            if (!this.isWaiting) return;
            this.isWaiting = false;
            this.choise = choise;

            StartCoroutine(this.CloseWindow());
        }

        protected IEnumerator CloseWindow()
        {
            this.windowCloseEvent.Invoke();
            yield return new WaitForSecondsRealtime(this.windowCloseTime);
            this.callback(this.choise);
            Destroy(this.gameObject);
        }

        public static ConfirmationWindow OpenWindow(ConfirmationWindow confirmationWindow, ConfirmCallback callback, string question = null)
        {
            var window = Instantiate(confirmationWindow.gameObject, null)
                    .GetComponent<ConfirmationWindow>();
            window.question = question;
            window.callback = callback;
            return window;
        }
    }

}
