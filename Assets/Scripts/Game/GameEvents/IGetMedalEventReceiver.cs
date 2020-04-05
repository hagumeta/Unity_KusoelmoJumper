using Extends.GameEvent;

public interface IGetMedalEventReceiver : IGameEventListener
{
    void OnEventRaised(int points);
}
