using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Extends.Motions
{
    public class DGSize : DGController
    {
        public Vector3 SizeFrom;
        public Vector3 SizeTo;

        public override IEnumerator PreDo()
        {
            this.transform.localScale = this.SizeFrom;
            yield return null;
        }

        public override IEnumerator MainDo(float doTime, Ease easeType)
        {
            this.transform.DOScale(this.SizeTo, doTime)
                .SetEase(easeType)
                .SetUpdate(true);
            yield return null;
        }
    }

}
