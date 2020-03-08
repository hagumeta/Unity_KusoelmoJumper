using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Chaser : MonoBehaviour
{

    public Transform TargetObject;
    public float DoTime;
    public Vector3 PositionDiff;
    protected Vector3 positionTo
        => this.TargetObject != null ? this.TargetObject.position + this.PositionDiff : this.transform.position;
    protected Vector3 positionToDiff
        => this.TargetObject != null ? this.TargetObject.position - this.transform.position + this.PositionDiff : this.transform.position;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.DoTime > 0)
        {
            this.transform.DOMove(this.positionToDiff, this.DoTime);
        }
        else
        {
            this.transform.DOKill();
            this.transform.position = this.positionTo;
        }
    }
}
