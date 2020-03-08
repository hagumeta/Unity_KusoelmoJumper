using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public class Life : BarStatus
    {
        public delegate void LifeEvent();
        public delegate void LifeChangedEvent(float x);
        protected LifeEvent OnLifeZero;
        protected LifeChangedEvent OnLifeRecovered;
        protected LifeChangedEvent OnLifeDamaged;

        protected override void OnValueChanged(float diff, float rawDiff)
        {
            if (rawDiff < 0 && this.OnLifeDamaged != null)
            {
                this.OnLifeDamaged(-rawDiff);
            }
            else if(diff > 0 && this.OnLifeRecovered != null)
            {
                this.OnLifeRecovered(diff);
            }

            if (this.IsMin && this.OnLifeZero != null)
            {
                this.OnLifeZero();
            }
        }

        public Life(float max, float def) : base(max, 0, def)
        {
        }
        public Life(float max) : this(max, max)
        {
        }

        public void SetLifeZeroEvent(LifeEvent lifeEvent)
        {
            this.OnLifeZero = lifeEvent;
        }
        public void SetLifeDamagedEvent(LifeChangedEvent lifeEvent)
        {
            this.OnLifeDamaged = lifeEvent;
        }
        public void SetLifeRecoveredEvent(LifeChangedEvent lifeEvent)
        {
            this.OnLifeRecovered = lifeEvent;
        }
    }
}