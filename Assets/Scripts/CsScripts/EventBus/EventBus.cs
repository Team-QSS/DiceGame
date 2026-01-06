using System;
using System.Collections.Generic;
using UnityEngine;

//전역 이벤트 버스
public static class EventBus
{
    // 이벤트 타입별 구독자 리스트
    private static Dictionary<Type, List<Delegate>> _subscribers = new Dictionary<Type, List<Delegate>>();

    // 이벤트 구독
    public static void Subscribe<T>(Action<T> callback)
    {
        Type eventType = typeof(T);

        if (!_subscribers.ContainsKey(eventType))
            _subscribers[eventType] = new List<Delegate>();

        _subscribers[eventType].Add(callback);
    }

    // 이벤트 구독 해제
    public static void Unsubscribe<T>(Action<T> callback)
    {
        Type eventType = typeof(T);

        if (_subscribers.ContainsKey(eventType))
        {
            _subscribers[eventType].Remove(callback);
            if (_subscribers[eventType].Count == 0)
                _subscribers.Remove(eventType);
        }
    }

    // 이벤트 발행
    public static void Publish<T>(T eventData)
    {
        Type eventType = typeof(T);

        if (_subscribers.ContainsKey(eventType))
        {
            foreach (Delegate del in _subscribers[eventType])
            {
                (del as Action<T>)?.Invoke(eventData);
            }
        }
    }
}

//전체적인 구조 각자스크립트의 초기화문에서 이벤트를 등록 -> 이벤트를 객체취급해서 새롭게 할당 -> 전역적으로 전파
//이걸 어떻게 활용 할 수 있냐 -> Tile.SetEffect()이 함수 안에 전역 이벤트로 이벤트 설정하고 이걸 코루틴으로 조작 가능!
