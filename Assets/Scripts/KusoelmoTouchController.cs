using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Actor.Kusoelmo;
using UnityEngine.EventSystems;

public class KusoelmoTouchController : MonoBehaviour
{
    public string KusoelmoTag;
    public float TouchRange;
    public float LowPower;
    public ShockWave shockWave;

    public float TimePowerRate;
    public float PowerLimit;

    private float touchTime;
    private int touchCount;
    private RectTransform RectTransform;
    protected GameObject TargetGameObject
        => GameObject.FindGameObjectWithTag(this.KusoelmoTag);


    void Start()
    {
        this.touchCount = 0;
        this.RectTransform = this.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.StartTouch();
        }
        if (Input.GetMouseButtonUp(0))
        {
            this.ReleaseTouch(Input.mousePosition);
        }
        if (Input.GetMouseButton(0))
        {
            this.StayTouch();
        }

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    this.StartTouch();
                    break;
                case TouchPhase.Ended:
                    this.ReleaseTouch(touch.position);
                    break;
                case TouchPhase.Canceled:
                    this.ReleaseTouch(touch.position);
                    break;
                case TouchPhase.Stationary:
                    this.StayTouch();
                    break;
                case TouchPhase.Moved:
                    this.StayTouch();
                    break;
            }
        }
        this.touchCount = Input.touchCount;
    }


    private void StayTouch()
    {
        this.touchTime += Time.deltaTime;
    }

    private void StartTouch() 
    {
        this.touchTime = 0;
    }

    private void ReleaseTouch(Vector2 position)
    {
        var power = Mathf.Clamp(this.LowPower + this.touchTime * this.TimePowerRate, 0f, this.PowerLimit);
        this.PushKusoelmo(position, power);
    }


    private void PushKusoelmo(Vector2 position, float power) 
    {
        var diff = (position - (Vector2)this.GetComponent<RectTransform>().position) / this.TouchRange;
        var size = this.TargetGameObject.transform.lossyScale;

        Debug.Log(size);
        this.BurstBomb((Vector2)this.TargetGameObject.transform.position + diff*size, power);
    }

    private void BurstBomb(Vector2 position, float power)
    {
        var inst = Instantiate(this.shockWave.gameObject, position, Quaternion.identity);
        inst.GetComponent<ShockWave>().Power = power;
        inst.GetComponent<ShockWave>().Size = power/this.LowPower + 2f;
        inst.transform.localScale *= power / this.LowPower;
    }


    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, this.TouchRange);
    }
}
