using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.StageObjects
{
    [RequireComponent(typeof(Collider))]
    public abstract class StageObject : MonoBehaviour
    {
        public abstract void OnCollided(Transform other);
    }
}
