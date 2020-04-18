using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Actor.Kusoelmo
{
    public class KusoelmoLifeViewer : LifeViewer
    {
        [SerializeField] protected Kusoelmo Kusoelmo;

        protected override Life ViewingLife 
        {
            get => this.GetKusoelmoLife();
        }

        protected Life GetKusoelmoLife()
        {
            if (this.Kusoelmo == null) return null;
            return this.Kusoelmo.Life;
        }
    }

}
