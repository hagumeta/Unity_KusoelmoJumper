using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Actor
{
    public class LifeViewer : MonoBehaviour
    {
        [SerializeField] private TMP_Text Text;
        protected virtual Life ViewingLife { get; set; }

        void Start()
        {
        }

        void Update()
        {
            this.RefreshView();
        }

        protected void RefreshView()
        {
            if (this.Text == null || this.ViewingLife == null) return;
            this.Text.text = this.ViewingLife.NowValue.ToString();
        }

    }

}
