using System.Collections;
using System.Collections.Generic;
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
            var medal = 0;
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
            throw new NotImplementedException();
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
