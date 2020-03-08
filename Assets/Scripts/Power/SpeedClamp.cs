using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpeedClamp : MonoBehaviour
{
    public float MaxSpeed;
    private new Rigidbody rigidbody;
    private void Start()
    {
        this.rigidbody = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var speed = this.rigidbody.velocity.magnitude;

        if (speed > this.MaxSpeed)
        {
            this.rigidbody.velocity = this.MaxSpeed * this.rigidbody.velocity.normalized;
        }
    }
}
