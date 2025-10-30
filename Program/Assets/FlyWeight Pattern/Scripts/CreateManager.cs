using System.Collections;
using UnityEngine;

public class CreateManager : MonoBehaviour
{
    [SerializeField] GameObject prefab;               // Inspector���� ������ ����

    [SerializeField] Transform createPosition;

    void Start()
    {
        StartCoroutine(CreateBear());
    }

    IEnumerator CreateBear()
    { 
        while (true)    // ���� �ݺ�
        {
            yield return CoroutineManager.GetCachedWait(Random.Range(1f, 6f));

            Instantiate(prefab, createPosition.position, prefab.transform.rotation);
        }
    }
}


// 1~5�� ���̿� �������� �� ����
// �������� �ٶ󺸰� �޷����� �ϱ�
// �ε����� Destroy Zone ��ũ��Ʈ�� ����