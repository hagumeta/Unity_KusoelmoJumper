using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Extends.Motions
{
    public class DGPosition : DGController
    {
        public Vector3 PositionFrom;
        public Vector3 PositionTo;
        public bool useWorldPosition;

        public override IEnumerator PreDo()
        {
            if (this.useWorldPosition)
            {
                this.transform.position = this.PositionFrom;
            }
            else
            {
                this.transform.localPosition = this.PositionFrom;
            }
            yield return null;
        }

        public override IEnumerator MainDo(float doTime, Ease easeType)
        {
            this.transform.DOLocalMove(this.PositionTo, doTime)
                .SetEase(easeType)
                .SetUpdate(true);
            yield return null;
        }


    }

}
