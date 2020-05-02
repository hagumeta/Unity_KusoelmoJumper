using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;
using Extends.Confirmations;

namespace Game.Controllers
{
    public class PauseController : MonoBehaviour
    {
        private StageController stageController;
        [SerializeField] private UnityEvent closeHandleEvent;
        [SerializeField] private float closeWindowTime;
        [SerializeField] private ConfirmationWindow confirmationWindow;

        private float time;

        void Start()
        {
            this.time = Time.timeScale;
            Time.timeScale = 0;
            this.stageController = GameObject.FindObjectOfType<StageController>();
        }

        public void ResumeGame()
        {
            StartCoroutine(this.CloseWindow());
        }

        public void RestartGame()
        {
            ConfirmationWindow.OpenWindow(this.confirmationWindow, this.ConfirmRestartGame, "やりなおす？");
        }


        public void BackTitle()
        {
            ConfirmationWindow.OpenWindow(this.confirmationWindow, this.ConfirmBackTitle, "ちゅうだんする？");
        }

        protected void ConfirmRestartGame(Choise choise)
        {
            if (choise == Choise.yes)
            {
                this.stageController.Restart();
            }
        }


        protected void ConfirmBackTitle(Choise choise)
        {
            if (choise == Choise.yes)
            {
                throw new NotImplementedException();
            }
        }


        private IEnumerator CloseWindow()
        {
            this.closeHandleEvent.Invoke();
            yield return new WaitForSecondsRealtime(this.closeWindowTime);
            this.stageController.RevertPause();
        }

        private void OnDestroy()
        {
            Time.timeScale = this.time;
        }
    }

}
