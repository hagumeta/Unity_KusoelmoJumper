using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Extends.WorldUI
{
    public class FillAmountSmoother : MonoBehaviour
    {
        [SerializeField] private Image barImage;
        [SerializeField] private Image decreaseEffectImage;
        [SerializeField] private Image increaseEffectImage;
        [SerializeField] private float effectSpeed;


        public void SetAmount(float value)
        {
            if (this.Amount > value)
            {
                //decrease
                this.Amount = value;
            }
            else
            {
                //increase
                this.IncreaseAmount = value;
            }
        }

        protected float Amount
        {
            get => this.barImage.fillAmount;
            set
            {
                this.barImage.fillAmount = value;
                this.ResolveAmounts();
            }
        }
        protected float DecreaseAmount
        {
            get => this.decreaseEffectImage.fillAmount;
            set 
            {
                this.decreaseEffectImage.fillAmount = value;
                this.ResolveAmounts();
            }
        }
        protected float IncreaseAmount
        {
            get => this.increaseEffectImage.fillAmount;
            set
            {
                this.increaseEffectImage.fillAmount = value;
                this.ResolveAmounts();
            }
        }


        private void ResolveAmounts()
        {
            if (this.Amount > this.DecreaseAmount)
            {
                this.DecreaseAmount = this.Amount;
            }
            if (this.Amount < this.IncreaseAmount)
            {
                this.IncreaseAmount = this.Amount;
            }
        }

        void Update()
        {
            if (this.DecreaseAmount > this.Amount)
            {
                this.DecreaseAmount -= this.effectSpeed;
            }
            if (this.IncreaseAmount > this.Amount)
            {
                this.Amount += this.effectSpeed;
            }
        }
    }

}
