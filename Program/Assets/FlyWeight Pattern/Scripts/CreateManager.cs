using System.Collections;
using UnityEngine;

public class CreateManager : MonoBehaviour
{
    [SerializeField] private GameObject bear;               // Inspector에서 프리팹 지정
    [SerializeField] private Vector3 bearPosition;

    private WaitForSeconds wait = new WaitForSeconds(5f);   // 캐싱 (가비지 방지)

    void Start()
    {
        // 처음 생성 위치를 이 오브젝트의 위치로 설정
        bearPosition = transform.position;
        StartCoroutine(CreateBear());
    }

    void Update()
    {

    }

    IEnumerator CreateBear()
    { 
        while (true)    // 무한 반복
        {
            Instantiate(bear, bearPosition, Quaternion.identity);

            bearPosition.x += 2f;  // x 좌표를 2만큼 증가시켜서 다음 곰이 옆에 생성되도록 함

            yield return wait;  // 5초 기다렸다가 다시 생성
        }
    }
}
