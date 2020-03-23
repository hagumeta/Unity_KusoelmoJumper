using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Actor;

namespace Game
{
    public class StartPoint : MonoBehaviour
    {

        [SerializeField] protected Actor.Actor Actor;
        [SerializeField] protected bool CreateOnStart;

        public void CreateActor()
        {
            var act = Instantiate(this.Actor.gameObject, this.transform.position, Quaternion.identity);
        }

        private void Start()
        {
            if (this.CreateOnStart)
            {
                this.CreateActor();
            }
        }
    }
}
