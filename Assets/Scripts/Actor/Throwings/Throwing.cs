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
            Destroy(this.gameObject);
        }

        public void ThrowTo(Vector3 to)
        {
            this.Throw(this.speed, to);
        }

        protected void Throw(float speed, Vector3 to) {
            var rigidbody = this.GetComponent<Rigidbody>();
            this.transform.LookAt(to, Vector3.forward);
            rigidbody.velocity = this.transform.up * speed;
        }
    }
}
