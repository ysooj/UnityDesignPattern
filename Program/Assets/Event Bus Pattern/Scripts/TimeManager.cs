using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] Text timeText;
    [SerializeField] float time;

    [SerializeField] int minute;
    [SerializeField] int second;
    [SerializeField] int microsecond;

    [SerializeField] bool state = true;

    private void OnEnable()
    {
        EventManager.Subscribe(Condition.START, Execute);
        EventManager.Subscribe(Condition.PAUSE, Pause);
        EventManager.Subscribe(Condition.FINISH, Exit);
    }

    void Execute()
    {
        StartCoroutine(Measure());
    }

    void Pause()
    {
        state = false;
    }

    public void Exit()
    {
        timeText.text = "Game Over";
    }

    public IEnumerator Measure()
    {
        while (state)
        {
            time -= Time.deltaTime;

            if (time <= 0)
            {
                EventManager.Publish(Condition.FINISH);
                Exit();

                yield break;
            }

            minute = (int)time / 60;
            second = (int)time % 60;
            microsecond = (int)(time * 100) % 100;

            timeText.text = string.Format("{0:D2} : {1:D2} : {2:D2}", minute, second, microsecond);

            yield return null;
        }
    }
    private void OnDisable()
    {
        EventManager.Unsubscribe(Condition.START, Execute);
        EventManager.Unsubscribe(Condition.PAUSE, Pause);
        EventManager.Unsubscribe(Condition.FINISH, Exit);
    }
}