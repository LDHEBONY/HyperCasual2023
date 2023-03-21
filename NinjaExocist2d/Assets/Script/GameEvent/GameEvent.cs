using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ninja2D/Game Event", fileName = "New Game Event")]
public class GameEvent : ScriptableObject {
    List<GameEventListener> listenersList = new List<GameEventListener>();

    public void Subscribe(GameEventListener listener) {
        listenersList.Add(listener);
    }

    public void Unsubscribe(GameEventListener listener) {
        listenersList.Remove(listener);
    }

    public void Dispatch() {
        listenersList.ForEach((listener) => {
            listener.Invoke();
        });
    }
}
