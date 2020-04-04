using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Controllers
{
    public class StageCanvasController : MonoBehaviour
    {
        private StageController stageController;

        [SerializeField] private TMPro.TMP_Text scoreText;

        void Start()
        {
            this.stageController = GameObject.FindObjectOfType<StageController>();
        }

        public void RestartGame()
        {
            this.stageController.Restart();
        }

        private void Update()
        {
            this.RefreshView();
        }

        private void RefreshView()
        {
            var score = this.stageController.GameScore;
            this.scoreText.text = score.Score.ToString();
        }
    }

}
