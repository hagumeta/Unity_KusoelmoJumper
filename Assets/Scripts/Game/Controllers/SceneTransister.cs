using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Controllers
{
    public class SceneTransister : MonoBehaviour
    {

        public static void MoveScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

}
