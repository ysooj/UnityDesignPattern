using System.Collections;
using UnityEngine;

public class Knife : Weapon
{
    [SerializeField] Animator animator;

    [SerializeField] Vector3 knifeMoving = Vector3.forward;
    [SerializeField] float distance = 0.5f; // Į�� ������ �Ÿ�
    [SerializeField] float speed = 2f; // Į�� �����̴� �ӵ�

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void Attack()
    {
        animator.SetTrigger("Attack");

        StartCoroutine(KnifeRoutine());

        gameObject.transform.Rotate(knifeMoving);
        Debug.Log("Knife Attack");
    }

    IEnumerator KnifeRoutine()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + knifeMoving * distance;

        // ������ �����̱�
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null; // ���� �����ӱ��� ���
        }

        // �ٽ� ����ġ�� ���ƿ���
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(endPos, startPos, t);
            yield return null;
        }
    }
}