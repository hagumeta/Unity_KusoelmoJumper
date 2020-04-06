using Extends.GameEvent;
using Actor;

namespace Game.GameEvents
{
    public interface IActorDeathEventListener : IGameEventListener
    {
        void OnEventRaised(Actor.Actor actor);
    }
}