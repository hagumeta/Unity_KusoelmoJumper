﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.GameEvents;


namespace Actor.Kusoelmo
{
    public class Kusoelmo : Actor
    {
        public ActorDeathEvent DeathEvent;
        public float CallDeathEventLagTime;
        public Life Life;
        public float MaxLife;
        public float LifeDecPerSecond;
        public Transform DeathEffect;

        public string Name
            => this.name;



        protected new string name = "クソエルモ";

        void Start()
        {
            this.Life = new Life(this.MaxLife);
            this.Life.SetLifeZeroEvent(this.Death);
        }


        float time = 0f;
        void Update()
        {
            time += Time.deltaTime;
            if (time > 1f)
            {
                this.Life.NowValue -= this.LifeDecPerSecond;
                time = 0;
            }
        }






        public override void Death()
        {
            this.Message(string.Format("{0} は じょうはつ した！", this.Name));
            Instantiate(this.DeathEffect.gameObject, this.transform.position, Quaternion.identity);
            this.DeathEvent.Raise(this);
            Destroy(this.gameObject);
        }

        public virtual void Damaged(float damage)
        {
            this.Life.NowValue -= damage;
            this.DamagedMessage(damage);
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

        protected override void OnCollisionEnter(Collision collision)
        {
            base.OnCollisionEnter(collision);
            if(collision.gameObject.tag == "Killer")
            {
                this.Damaged(114514f);
            }
        }
    }
}
