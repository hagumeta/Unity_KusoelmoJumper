using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CustomGravity : MonoBehaviour
{
    public Vector3 GravityForce;    
    
    private new Rigidbody rigidbody;
    private Vector3 force
        => this.GravityForce * Physics.gravity.magnitude;


    private void Start()
    {
        this.rigidbody = this.GetComponent<Rigidbody>();
        this.rigidbody.useGravity = false;
    }

    private void FixedUpdate()
    {
        this.rigidbody.AddForce(this.force, ForceMode.Acceleration);
    }
}
