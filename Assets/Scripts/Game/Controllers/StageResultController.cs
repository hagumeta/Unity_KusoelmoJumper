using System;
using UnityEngine;

namespace Game.Controllers
{
    public class StageResultController : MonoBehaviour
    {
        private StageController stageController;
        private ResultWindowHandler windowHandler;

        public void Start()
        {
            this.stageController = GameObject.FindObjectOfType<StageController>();
            this.windowHandler = GameObject.FindObjectOfType<ResultWindowHandler>();
            if (this.stageController == null || this.windowHandler == null)
            {
                throw new Exception("StageController or ResultWindowHandler can not found");
            }
            this.Init();
        }

        public void Init()
        {
            var score = this.stageController.GameScore.Score;
            var medal = this.stageController.GameMedal.Medal;
            this.windowHandler.SetScore(score);
            this.windowHandler.SetMedal(medal);
        }


        public void RetryGame()
        {
            this.stageController.Restart();
        }

        public void GotoShop()
        {
            throw new NotImplementedException();
        }

        public void GotoTitle()
        {
            var controller = FindObjectOfType<GameController>();
            controller.GotoTitle();
        }

        public void Share()
        {
            throw new NotImplementedException();
        }

        public void ShowRanking()
        {
            throw new NotImplementedException();
        }
    }
}
