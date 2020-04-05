using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    public class GameController : SingletonMonoBehaviour<GameController>
    {
        [SerializeField] SceneObject TitleScene;
        [SerializeField] SceneObject StageScene;


        public static void GotoTitle()
        {
            Instance.gotoTitle();
        }

        public static void GotoStage()
        {
            Instance.gotoStage();
        }

        public static void GameEnd()
        {
            Instance.gameEnd();
        }


        private void gotoTitle()
        {
            SceneTransister.MoveScene(this.TitleScene);
        }

        private void gotoStage()
        {
            SceneTransister.MoveScene(this.StageScene);
        }

        private void gameEnd()
        {
            Application.Quit(0);
        }
    }
}
