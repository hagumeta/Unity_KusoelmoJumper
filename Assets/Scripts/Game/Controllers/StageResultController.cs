﻿using System;
using UnityEngine;
using Game.Result;

namespace Game.Controllers
{
    public class StageResultController : MonoBehaviour
    {
        [SerializeField] private ResultWindowHandler windowHandler;
        private StageController stageController;

        public void Start()
        {
            this.stageController = GameObject.FindObjectOfType<StageController>();
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
            GameController.GotoTitle();
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
