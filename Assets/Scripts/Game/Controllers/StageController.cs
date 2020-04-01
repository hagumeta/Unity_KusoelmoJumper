using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Game.GameEvents;
using Game.Models;

namespace Game.Controllers
{
    [RequireComponent(typeof(GameScore))]
    public class StageController : MonoBehaviour, IActorDeathEventListener
    {
        public SceneObject ResultScene;
        public SceneObject StageCanvasScene;

        public GameScore GameScore { get; private set; }
        private bool isGaming;

        private void Start()
        {
            this.GameScore = this.GetComponent<GameScore>();
            if (!SceneManager.GetSceneByName(this.StageCanvasScene).isLoaded)
            {
                SceneManager.LoadScene((string)this.StageCanvasScene, LoadSceneMode.Additive);
            }
        }

        protected void GameStart()
        {
            this.GameScore.ResetScore();
        }
        protected void GameOver()
        {
            if (!SceneManager.GetSceneByName(this.ResultScene).isLoaded)
            {
                SceneManager.LoadScene((string)this.ResultScene, LoadSceneMode.Additive);
            }
        }

        protected void GameResult()
        {

        }

        protected void GameReset()
        {

        }

        public void OnEventRaised(Actor.Actor actor)
        {
            this.GameOver();
        }
        public void OnEventRaised()
        {
        }
    }
}