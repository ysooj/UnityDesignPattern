using System.Collections.Generic;
using UnityEngine;

// �ڷ�ƾ���� ����ϴ� WaitForSeconds ��ü�� ĳ���Ͽ�, ���ʿ��� ������ ������ �����ִ� �Ŵ��� Ŭ����
public static class CoroutineManager
{
    // Dictionary�� float(�ð�)�� key��, WaitForSeconds ��ü�� value�� ����
    private static Dictionary<float, WaitForSeconds> dictionary = new();

    public static WaitForSeconds GetCachedWait(float time)
    {
        WaitForSeconds waitForSeconds = null;

        // �ش� �ð��� Dictionary�� ��������� �ʴٸ�, ���� �����Ͽ� �߰�
        if (dictionary.TryGetValue(time, out waitForSeconds) == false)
        {
            // ���ο� WaitForSeconds ��ü �����ϰ�,
            // ���� ���� ��ü�� Dictionary�� �߰��Ͽ�, ������ ���� �ð��� ��û�Ǹ� ������ �� �ְ� ��
            dictionary.Add(time, new WaitForSeconds(time));

            waitForSeconds = dictionary[time];
        }

        // �̹� ��������ٸ� ���� ������ �ʰ� �� ��ü�� �״�� ��ȯ
        return waitForSeconds;
    }
}