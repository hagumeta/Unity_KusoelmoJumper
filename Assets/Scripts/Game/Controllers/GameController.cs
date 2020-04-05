using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] SceneObject TitleScene;
        [SerializeField] SceneObject StageScene;

        private void Start()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        public void GotoTitle()
        {
            SceneTransister.MoveScene(this.TitleScene);
        }

        public void GotoStage()
        {
            SceneTransister.MoveScene(this.StageScene);
        }

        public void GameEnd()
        {
            Application.Quit(0);
        }
    }
}
