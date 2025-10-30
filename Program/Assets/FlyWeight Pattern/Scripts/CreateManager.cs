using System.Collections;
using UnityEngine;

public class CreateManager : MonoBehaviour
{
    [SerializeField] GameObject prefab;               // Inspector에서 프리팹 지정

    [SerializeField] Transform createPosition;

    void Start()
    {
        StartCoroutine(CreateBear());
    }

    IEnumerator CreateBear()
    { 
        while (true)    // 무한 반복
        {
            yield return CoroutineManager.GetCachedWait(Random.Range(1f, 6f));

            Instantiate(prefab, createPosition.position, prefab.transform.rotation);
        }
    }
}


// 1~5초 사이에 랜덤으로 곰 생성
// 내쪽으로 바라보고 달려오게 하기
// 부딪히면 Destroy Zone 스크립트로 제거