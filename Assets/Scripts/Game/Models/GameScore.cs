using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.Models
{
    public class GameScore
    {
        public int Score { get; set; }
        public void ResetScore()
        {
            this.Score = 0;
        }
    }
}
