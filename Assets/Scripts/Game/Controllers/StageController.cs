using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.GameEvents;

namespace Game.Controllers
{

    public class StageController : MonoBehaviour, IActorDeathEventListener
    {
        private bool isGaming;
        protected void GameStart()
        {

        }
        protected void GameOver()
        {
            Debug.LogError("GAME OVER");
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