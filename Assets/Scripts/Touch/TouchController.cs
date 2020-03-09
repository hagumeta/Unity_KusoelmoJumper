using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Touch
{
    public class TouchController : MonoBehaviour
    {
        private float touchTime;
        private Vector3 touchPosition;





        private void Update()
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
            }
        }
    }

}
