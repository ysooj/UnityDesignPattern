using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float stopDistance = 0.1f; // 목표 지점에 얼마나 가까워졌는 지 확인하는 변수

    [SerializeField] bool isMoving = false;
    [SerializeField] Vector3 targetPosition;

    [SerializeField] RaycastHit rayCastHit;

    void Start()
    {
        targetPosition = transform.position; // 초기 위치 설정
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))   // 마우스 왼쪽 버튼 클릭
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out rayCastHit))
            {
                targetPosition = rayCastHit.point;    // 클릭한 위치 저장

                isMoving = true;

                //targetPosition.y = 0; // y축 고정
            }
        }

        if (isMoving)
        {
            Move();
        }
    }

    public void Move()
    {
        // 목표 지점 방향 계산
        Vector3 direction = (targetPosition - transform.position).normalized;

        float distance = Vector3.Distance(transform.position, targetPosition);

        transform.position += direction * speed * Time.deltaTime; // 이동

        // 도착 지점 확인
        if (distance <= stopDistance)
        {
            isMoving = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fear"))
        {
            Debug.Log("Fear Debuff Applied");
        }

        if (other.CompareTag("Silence"))
        {
            Debug.Log("Silence Debuff Applied");
        }

        if (other.CompareTag("Slow"))
        {
            Debug.Log("Slow Debuff Applied");
        }
    }
}
