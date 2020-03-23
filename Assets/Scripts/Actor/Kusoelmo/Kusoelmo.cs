using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Actor;

namespace Actor.Kusoelmo
{
    public class Kusoelmo : Actor
    {
        public Life Life;
        public float MaxLife;
        public string Name
            => this.name;


        protected new string name = "クソエルモ";

        void Start()
        {
            this.Life = new Life(this.MaxLife);
            this.Life.SetLifeZeroEvent(this.Death);
            this.Life.SetLifeDamagedEvent(this.DamagedMessage);
        }

        void Update()
        {
        }

        public void Death()
        {
            this.Message(string.Format("{0} は じょうはつ した！", this.Name));
            Destroy(this.gameObject);
        }

        public virtual void Damaged(float damage)
        {
            this.Life.NowValue -= damage;
        }


        public void DamagedMessage(float damage)
        {
            this.Message(string.Format("{0} は {1}ダメージ を うけた！", this.Name, damage));
            this.Message(string.Format("{0} の のこりLife： {1}", this.Name, this.Life.NowValue));
        }

        protected void Message(string text)
        {
            Debug.Log(text);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Killer")
            {
                this.Damaged(114514f);
            }
        }
    }
}
