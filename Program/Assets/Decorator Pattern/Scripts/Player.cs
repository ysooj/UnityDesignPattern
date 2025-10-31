using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float stopDistance = 0.1f; // ��ǥ ������ �󸶳� ��������� �� Ȯ���ϴ� ����

    [SerializeField] bool isMoving = false;
    [SerializeField] Vector3 targetPosition;

    [SerializeField] RaycastHit rayCastHit;

    void Start()
    {
        targetPosition = transform.position; // �ʱ� ��ġ ����
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))   // ���콺 ���� ��ư Ŭ��
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out rayCastHit))
            {
                targetPosition = rayCastHit.point;    // Ŭ���� ��ġ ����

                isMoving = true;

                //targetPosition.y = 0; // y�� ����
            }
        }

        if (isMoving)
        {
            Move();
        }
    }

    public void Move()
    {
        // ��ǥ ���� ���� ���
        Vector3 direction = (targetPosition - transform.position).normalized;

        float distance = Vector3.Distance(transform.position, targetPosition);

        transform.position += direction * speed * Time.deltaTime; // �̵�

        // ���� ���� Ȯ��
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
