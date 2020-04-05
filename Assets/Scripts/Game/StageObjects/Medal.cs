using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.StageObjects
{
    public class Medal : Item
    {
        [SerializeField] protected int Point;
        private Controllers.StageController stageController;
        private void Start()
        {
            this.stageController = FindObjectOfType<Controllers.StageController>();
        }
        protected override void OnGetted(Transform other)
        {
            this.stageController.GetMedal(this.Point);
        }
    }
}
