using UnityEngine;
using Extends.GameEvent;
using Actor;
using System;

namespace Game.GameEvents
{
    [CreateAssetMenu(fileName = "New Actor Death Event", menuName = "Actor Death Event", order = 52)] // 1
    public class ActorDeathEvent : GameEvent<IActorDeathEventListener>
    {
        public void Raise(Actor.Actor actor)
        {
            foreach (IActorDeathEventListener listener in this.Listeners)
            {
                listener.OnEventRaised(actor);
            }
        }

        public override void Raise()
        {
            throw new NotImplementedException();
        }
    }
}