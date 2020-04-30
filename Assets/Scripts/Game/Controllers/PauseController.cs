using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;
using Extends.Motions;

namespace Game.Controllers
{
    public class PauseController : MonoBehaviour
    {
        private StageController stageController;
        [SerializeField] private UnityEvent closeHandleEvent;
        [SerializeField] private float closeWindowTime;

        private float time;

        void Start()
        {
            this.time = Time.timeScale;
            Time.timeScale = 0;
            this.stageController = GameObject.FindObjectOfType<StageController>();
        }

        public void RestartGame()
        {
            this.stageController.Restart();
        }

        public void ResumeGame()
        {
            StartCoroutine(this.CloseWindow());
        }

        public void BackTitle()
        {
            throw new NotImplementedException();
        }

        private IEnumerator CloseWindow()
        {
            this.closeHandleEvent.Invoke();
            yield return new WaitForSeconds(this.closeWindowTime);
            Time.timeScale = this.time;
            this.stageController.RevertPause();
        }
    }

}
