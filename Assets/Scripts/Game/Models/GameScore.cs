using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Models
{
    public class GameScore : MonoBehaviour
    {
        public int Score { get; set; }
        public void ResetScore()
        {
            this.Score = 0;
        }
    }
}
