using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour {
    [SerializeField] GameEvent EventType;

    public UnityEvent Callback;

    void OnEnable() {
        if (EventType == null) {
            Debug.Log("[GameEventListener] �̺�Ʈ�� ��ϵ��� ����", this);
            return;
        }
        EventType.Subscribe(this);
    }

    void OnDisable() {
        if (EventType == null) {
            Debug.Log("[GameEventListener] �̺�Ʈ�� ��ϵ��� ����", this);
            return;
        }
        EventType.Unsubscribe(this);
    }

    public void Invoke() {
        Callback?.Invoke();
    }
}
