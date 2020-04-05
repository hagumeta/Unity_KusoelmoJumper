using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extends.GameEvent;

namespace Game.GameEvents
{
    public class GetMedalEvent : GameEvent<IGetMedalEventReceiver>
    {
        public virtual void Raise(int points = 1)
        {
            foreach (IGetMedalEventReceiver listener in this.Listeners)
            {
                listener.OnEventRaised(points);
            }
        }
    }

}
