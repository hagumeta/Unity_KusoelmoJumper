using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class ShockWave : MonoBehaviour
{
    [SerializeField] public float Power = 10;
    [SerializeField] public float Size = 2;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, Time.deltaTime*5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        var rigid = this.GetParentRigidbody(other.gameObject);
        if (rigid != null)
        {
            rigid.AddExplosionForce(this.Power, this.transform.position, this.Size);
        }
    }

    protected Rigidbody GetParentRigidbody(GameObject gameObject, int depth = 99)
    {
        if (depth <= 0 || gameObject == null) return null;
        var rigid = gameObject.GetComponent<Rigidbody>();
        if (rigid != null)
        {
            return rigid;
        }
        return this.GetParentRigidbody(gameObject.transform.parent.gameObject, --depth);
    }
}
