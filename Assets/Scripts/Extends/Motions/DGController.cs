using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Extends.Motions
{
    public abstract class DGController : MonoBehaviour
    {
        public float DoTime;
        public Ease EaseType;

        public float WaitTime;

        void Start()
        {
            StartCoroutine(this.Do());
        }

        private IEnumerator Do()
        {
            yield return this.PreDo();
            yield return new WaitForSeconds(this.WaitTime);
            yield return this.MainDo(this.DoTime, this.EaseType);
        }
        public abstract IEnumerator PreDo();
        public abstract IEnumerator MainDo(float DoTime, Ease easeType);
    }
}