using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Game.GameEvents;
using Game.Models;

namespace Game.Controllers
{
    public class StageController : MonoBehaviour, IActorDeathEventListener, IGetMedalEventReceiver
    {
        [SerializeField] private SceneObject ResultScene;
        [SerializeField] private SceneObject StageCanvasScene;
        [SerializeField] private SceneObject PauseScene;

        public GameScore GameScore { get; private set; }
        public GameMedal GameMedal { get; private set; }

        private bool isGaming;

        private void Start()
        {
            this.GameScore = new GameScore();
            this.GameMedal = new GameMedal();
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

        public void GetMedal(int points)
        {
            this.GameMedal.Medal += points;
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void StartPause()
        {
            if (!SceneManager.GetSceneByName(this.ResultScene).isLoaded)
            {
                SceneManager.LoadScene((string)this.PauseScene, LoadSceneMode.Additive);
            }
        }

        public void RevertPause()
        {
            if (SceneManager.GetSceneByName(this.PauseScene).isLoaded)
            {
                SceneManager.UnloadScene((string)this.PauseScene);
            }
        }


        void IActorDeathEventListener.OnEventRaised(Actor.Actor actor)
        {
            this.GameOver();
        }
        void IGetMedalEventReceiver.OnEventRaised(int points)
        {
            this.GetMedal(points);
        }

        public void OnEventRaised()
        {
        }
    }
}