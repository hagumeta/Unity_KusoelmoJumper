using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Actor.Kusoelmo
{
    public class KusoelmoLifeViewer : LifeViewer
    {
        [SerializeField] protected Kusoelmo Kusoelmo;
        [SerializeField] private Image gaugeImage;

        protected override Life ViewingLife 
        {
            get => this.GetKusoelmoLife();
        }

        protected Life GetKusoelmoLife()
        {
            if (this.Kusoelmo == null) return null;
            return this.Kusoelmo.Life;
        }

        protected override void RefreshView()
        {
            base.RefreshView();
            this.gaugeImage.fillAmount = this.ViewingLife.Percent;
        }
    }

}
