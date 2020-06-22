using UnityEngine;

namespace Actor.Throwings 
{
    [RequireComponent(typeof(Rigidbody))]
    public class Throwing : MonoBehaviour
    {
        [SerializeField] protected ShockWave shockWave;
        [SerializeField] protected float speed;


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponentInChildren<Kusoelmo.Kusoelmo>() != null)
            {
                this.Burst();
            }
        }

        protected void Burst()
        {
            var a = Instantiate(this.shockWave);
            a.enabled = true;
            var pos = this.transform.position;
            pos.z = 0;
            a.transform.position = pos;
            Destroy(this.gameObject);
        }

        public void ThrowTo(Vector3 to)
        {
            this.Throw(this.speed, to);
        }

        protected void Throw(float speed, Vector3 to) {
            var rigidbody = this.GetComponent<Rigidbody>();
            this.transform.LookAt(to, Vector3.up);
            rigidbody.velocity = this.transform.forward * speed;
        }
    }
}
