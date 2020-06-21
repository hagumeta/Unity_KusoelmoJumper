using UnityEngine;
using Actor.Throwings;
using System.Runtime.CompilerServices;

namespace Actor
{
    public class Thrower : MonoBehaviour
    {
        public Throwing throwing;

        public void ThrowTo(Vector3 target)
        {
            var inst = Instantiate(this.throwing);
            inst.transform.position = this.transform.position;
            inst.GetComponent<Throwing>().ThrowTo(target);
        }
    }
}
