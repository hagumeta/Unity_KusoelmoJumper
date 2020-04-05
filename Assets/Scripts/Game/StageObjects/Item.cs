using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extends.GameEvent;

namespace Game.StageObjects
{
    [RequireComponent(typeof(Collider))]
    public abstract class Item : StageObject
    {
        [SerializeField] protected bool IsDeleatable;
        abstract protected void OnGetted(Transform other);

        public override void OnCollided(Transform other)
        {
            this.OnGetted(other);
            if (this.IsDeleatable)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
