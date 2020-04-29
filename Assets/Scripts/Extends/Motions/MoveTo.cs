using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace Extends.Motions
{
    public class MoveTo : MonoBehaviour
    {
        public Vector2 toPos;
        public float time;

        void Start()
        {
            this.Move();
        }

        public void Move()
        {
            this.transform.DOMove(this.toPos, this.time);
        }
    }
}
