using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Actor
{
    public abstract class Actor : MonoBehaviour
    {
        public abstract void Death();

        
        protected virtual void OnTriggerEnter(Collider other)
        {
            var item = other.GetComponent<Game.StageObjects.Item>();
            if (item != null) {
                item.OnCollided(this.transform);
            }
        }

        protected virtual void OnCollisionEnter(Collision collision)
        {
        }
    }
}