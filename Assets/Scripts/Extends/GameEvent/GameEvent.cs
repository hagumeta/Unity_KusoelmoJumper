using UnityEngine;
using System.Linq;

namespace Extends.GameEvent
{
    [CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event", order = 52)] // 1
    public class GameEvent<T> : ScriptableObject where T : IGameEventListener// 2
    {
        protected T[] Listeners
            => FindObjectsOfType<MonoBehaviour>().OfType<T>().ToArray();

        public virtual void Raise()
        {
            foreach (T listener in this.Listeners)
            {
                listener.OnEventRaised();
            }
        }
    }
}