using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public enum Condition
{
    START,
    PAUSE,
    FINISH
}

public static class EventManager
{
    // Condition별로 이벤트(Action)를 관리하는 딕셔너리
    static Dictionary<Condition, Action> dictionary = new Dictionary<Condition, Action>();  // new(); 라고만 적어도 됨
    //  static Dictionary<Condition, Action> dictionary = new();  // new(); 라고만 적어도 됨

    // 특정 Condition에 이벤트를 구독(등록)합니다.
    public static void Subscribe(Condition condition, Action action)
    {
        if (dictionary.ContainsKey(condition))  // 이미 등록된 이벤트가 있는 경우             (O)
        {
            dictionary[condition] += action;    // 기존 envent에 추가 (+=)
        }

        else                                    // 해당 Condition에 등록된 이벤트가 없는 경우 (X)
        {
            dictionary[condition] = action;     // envent 새로 등록 (=)
        }
    }

    public static void Unsubscribe(Condition condition, Action action)
    {
        if (dictionary.ContainsKey(condition))  // 해당 Condition이 등록되어 있을 때
        {
            dictionary[condition] -= action;    // 이벤트 목록에서 action 제거 ; 구독 해제 (-=)
        }

        // GPT : else와 return이 없어도 무방함. 조건이 없으면 그냥 함수 종료되어 아무 작업도 하지 않음
        // retun이 없어도 될 듯. if로 들어왔다가 아무것도 없으면 그냥 나가니까.
        //  else                                    // Condition이 없으면 
        //  {
        //      return;                             // 아무 작업 없이 종료 (안전하게 return)
        //  }
    }

    public static void Publish(Condition condition)
    {
        // 해당 Condition이 등록되어 있다면, 연결된 이벤트(Action)를 가져옴
        if (dictionary.TryGetValue(condition, out var action))
        {
            // ?. 연산자는 null 안전 연산자 (action이 null이 아닐 때만 Invoke 실행)
            action?.Invoke();
        }
    }
}