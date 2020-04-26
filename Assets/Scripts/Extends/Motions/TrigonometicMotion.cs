using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Extends.Motions
{
    public class TrigonometicMotion : MonoBehaviour
    {

        public enum TrigonometicFunction
        {
            sin,
            cos,
            tan,
            noone
        }


        private Vector3 fundPosition;
        public Motion H_Motion, V_Motion, Z_Motion;

        [System.Serializable]
        public class Motion
        {
            public TrigonometicFunction motionFunc;

            public float angle, angleSpeed, radius;

            private void Update()
            {

                var radian = this.angle * Mathf.Deg2Rad;
                switch (this.motionFunc)
                {
                    case TrigonometicFunction.sin:
                        this.output = this.radius * Mathf.Sin(radian);
                        break;

                    case TrigonometicFunction.cos:
                        this.output = this.radius * Mathf.Cos(radian);
                        break;

                    case TrigonometicFunction.tan:
                        this.output = this.radius * Mathf.Tan(radian);
                        break;

                    case TrigonometicFunction.noone:
                        this.output = 0;
                        break;
                }

                this.angle += this.angleSpeed;
            }

            private float output;

            public float Output
            {
                get
                {
                    this.Update();
                    return this.output;
                }

            }
        }

        private void Start()
        {
            this.fundPosition = this.transform.position;
        }


        void Update()
        {
            Vector3 pos = new Vector3(this.H_Motion.Output, this.V_Motion.Output, this.Z_Motion.Output);

            this.transform.position = this.fundPosition + pos;
        }
    }

}