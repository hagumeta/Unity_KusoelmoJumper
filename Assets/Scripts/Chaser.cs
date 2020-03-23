using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class Chaser : MonoBehaviour
{

    public Vector3 TargetPosition;
    public string TargetTag;
    public float DoTime;
    public Vector3 PositionDiff;
    protected Vector3 positionTo
        => this.TargetPosition != null ? this.TargetPosition + this.PositionDiff : this.transform.position;
    protected Vector3 positionToDiff
        => this.TargetPosition != null ? this.TargetPosition - this.transform.position + this.PositionDiff : this.transform.position;

    void Start()
    {

    }

    void Update()
    {
        var list = new List<GameObject>(GameObject.FindGameObjectsWithTag(this.TargetTag));
        if (list.Count > 0) {
            this.TargetPosition = this.Centor(list.Select(a => a.transform.position).ToList());
        }

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

    private Vector3 Centor(List<Vector3> list)
    {
        var pos = Vector3.zero;
        foreach (var p in list)
        {
            pos += p;
        }
        return pos / list.Count;
    }
}
