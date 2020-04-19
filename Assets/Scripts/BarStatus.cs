using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarStatus
{
    private float max;
    private float now;
    private float min;

    public float MaxValue
    {
        get => this.max;
        set => this.SetMax(value);
    }
    public float NowValue
    {
        get => this.now;
        set => this.SetNow(value);
    }
    public float MinValue
    {
        get => this.min;
        set => this.SetMin(value);
    }
    public float Percent
    {
        get => this.NowValue/(this.MaxValue - this.MinValue);
        set => this.SetNow(value * (this.MaxValue - this.MinValue));
    }
    public bool IsMax
        => this.now == this.max;
    public bool IsMin
        => this.now == this.min;
    protected virtual void OnValueChanged(float diff, float rawDiff){}

    public void SetMax(float max)
    {
        this.max = max;
        this.min = this.min > this.max ? this.min : this.min;
        this.NowValue = this.now;
    }
    public void SetMin(float min)
    {
        this.min = min;
        this.max = this.max < this.min ? this.max : this.min;
        this.NowValue = this.now;
    }
    public void SetNow(float value)
    {
        var prev = this.now;
        this.now = value > this.max ? this.max : (value < this.min ? this.min : value);
        this.OnValueChanged(prev - this.now, value - this.now);
    }
    

    public BarStatus(float max, float min) : this(max, min, max)
    {
    }

    public BarStatus(float max, float min, float dif)
    {
        this.max = max;
        this.now = dif;
        this.min = min;
    }

}
