using System.Collections;
using UnityEngine;

public class CreateManager : MonoBehaviour
{
    [SerializeField] private GameObject bear;               // Inspector���� ������ ����
    [SerializeField] private Vector3 bearPosition;

    private WaitForSeconds wait = new WaitForSeconds(5f);   // ĳ�� (������ ����)

    void Start()
    {
        // ó�� ���� ��ġ�� �� ������Ʈ�� ��ġ�� ����
        bearPosition = transform.position;
        StartCoroutine(CreateBear());
    }

    void Update()
    {

    }

    IEnumerator CreateBear()
    { 
        while (true)    // ���� �ݺ�
        {
            Instantiate(bear, bearPosition, Quaternion.identity);

            bearPosition.x += 2f;  // x ��ǥ�� 2��ŭ �������Ѽ� ���� ���� ���� �����ǵ��� ��

            yield return wait;  // 5�� ��ٷȴٰ� �ٽ� ����
        }
    }
}
