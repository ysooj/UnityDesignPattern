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
    // Condition���� �̺�Ʈ(Action)�� �����ϴ� ��ųʸ�
    static Dictionary<Condition, Action> dictionary = new Dictionary<Condition, Action>();  // new(); ��� ��� ��
    //  static Dictionary<Condition, Action> dictionary = new();  // new(); ��� ��� ��

    // Ư�� Condition�� �̺�Ʈ�� ����(���)�մϴ�.
    public static void Subscribe(Condition condition, Action action)
    {
        if (dictionary.ContainsKey(condition))  // �̹� ��ϵ� �̺�Ʈ�� �ִ� ���             (O)
        {
            dictionary[condition] += action;    // ���� envent�� �߰� (+=)
        }

        else                                    // �ش� Condition�� ��ϵ� �̺�Ʈ�� ���� ��� (X)
        {
            dictionary[condition] = action;     // envent ���� ��� (=)
        }
    }

    public static void Unsubscribe(Condition condition, Action action)
    {
        if (dictionary.ContainsKey(condition))  // �ش� Condition�� ��ϵǾ� ���� ��
        {
            dictionary[condition] -= action;    // �̺�Ʈ ��Ͽ��� action ���� ; ���� ���� (-=)
        }

        // GPT : else�� return�� ��� ������. ������ ������ �׳� �Լ� ����Ǿ� �ƹ� �۾��� ���� ����
        // retun�� ��� �� ��. if�� ���Դٰ� �ƹ��͵� ������ �׳� �����ϱ�.
        //  else                                    // Condition�� ������ 
        //  {
        //      return;                             // �ƹ� �۾� ���� ���� (�����ϰ� return)
        //  }
    }

    public static void Publish(Condition condition)
    {
        // �ش� Condition�� ��ϵǾ� �ִٸ�, ����� �̺�Ʈ(Action)�� ������
        if (dictionary.TryGetValue(condition, out var action))
        {
            // ?. �����ڴ� null ���� ������ (action�� null�� �ƴ� ���� Invoke ����)
            action?.Invoke();
        }
    }
}