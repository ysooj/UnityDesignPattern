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
    static Dictionary<Condition, Action> dictionary = new Dictionary<Condition, Action>();  // new(); 라고만 적어도 됨
    //  static Dictionary<Condition, Action> dictionary = new();  // new(); 라고만 적어도 됨

    public static void Subscribe(Condition condition, Action action)
    {
        if (dictionary[condition] == null)
        {
            dictionary[condition] += action;
        }

        else
        {
            dictionary[condition] = action;
        }
    }
}