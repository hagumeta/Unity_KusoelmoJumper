using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Controllers
{
    public class TitleController : MonoBehaviour
    {
        public void GotoStageScene()
        {
            GameController.GotoStage();
        }

        public void ShowRanking()
        {
            throw new System.NotImplementedException();
        }

        public void GotoShop()
        {
            throw new System.NotImplementedException();
        }
    }

}
