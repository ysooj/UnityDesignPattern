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
    static Dictionary<Condition, Action> dictionary = new Dictionary<Condition, Action>();  // new(); ��� ��� ��
    //  static Dictionary<Condition, Action> dictionary = new();  // new(); ��� ��� ��

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