using System.Collections.Generic;
using UnityEngine;

// 코루틴에서 사용하는 WaitForSeconds 객체를 캐싱하여, 불필요한 가비지 생성을 막아주는 매니저 클래스
public static class CoroutineManager
{
    // Dictionary는 float(시간)을 key로, WaitForSeconds 객체를 value로 저장
    private static Dictionary<float, WaitForSeconds> dictionary = new();

    public static WaitForSeconds GetCachedWait(float time)
    {
        WaitForSeconds waitForSeconds = null;

        // 해당 시간이 Dictionary에 저장돼있지 않다면, 새로 생성하여 추가
        if (dictionary.TryGetValue(time, out waitForSeconds) == false)
        {
            // 새로운 WaitForSeconds 객체 생성하고,
            // 새로 만든 객체를 Dictionary에 추가하여, 다음에 같은 시간이 요청되면 재사용할 수 있게 함
            dictionary.Add(time, new WaitForSeconds(time));

            waitForSeconds = dictionary[time];
        }

        // 이미 만들어졌다면 새로 만들지 않고 그 객체를 그대로 반환
        return waitForSeconds;
    }
}