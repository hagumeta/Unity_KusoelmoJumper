using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Game.GameEvents;
using Game.Models;

namespace Game.Controllers
{
    public class StageController : MonoBehaviour, IActorDeathEventListener
    {
        [SerializeField] private SceneObject ResultScene;
        [SerializeField] private SceneObject StageCanvasScene;

        public GameScore GameScore { get; private set; }
        private bool isGaming;

        private void Start()
        {
            this.GameScore = new GameScore();
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

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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