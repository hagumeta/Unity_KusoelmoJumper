using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Controllers
{
    public class TitleController : MonoBehaviour
    {
        [SerializeField] private Transform TitleMenu;

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

        public void ShowTitleMenu()
        {
            this.TitleMenu.gameObject.SetActive(true);
        }

        public void HideTitleMenu()
        {
            this.TitleMenu.gameObject.SetActive(false);
        }
    }

}
