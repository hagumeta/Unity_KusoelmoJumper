using UnityEngine;

namespace GodTouches
{
    public class Demo : MonoBehaviour
    {
        public Transform Move;

        Vector3 startPos;

        void Start()
        {
            startPos = Move.position;
        }

        void Update()
        {
            // タッチを検出して動かす
            var phase = GodTouch.GetPhase();
            if (phase == GodPhase.Began)
            {
                startPos = Move.position;
            }
            else if (phase == GodPhase.Moved)
            {
                Move.position = GodTouch.GetPosition();
                //             Move.position += GodTouch.GetDeltaPosition(); 
            }
            else if (phase == GodPhase.Ended)
            {
                Move.position = startPos;
            }
        }
    }
}