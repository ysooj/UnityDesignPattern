using System.Collections;
using UnityEngine;

public class Knife : Weapon
{
    [SerializeField] Animator animator;

    [SerializeField] Vector3 knifeMoving = Vector3.forward;
    [SerializeField] float distance = 0.5f; // 칼이 움직일 거리
    [SerializeField] float speed = 2f; // 칼이 움직이는 속도

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

        // 앞으로 움직이기
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null; // 다음 프레임까지 대기
        }

        // 다시 원위치로 돌아오기
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(endPos, startPos, t);
            yield return null;
        }
    }
}