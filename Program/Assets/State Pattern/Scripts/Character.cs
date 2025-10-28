using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    public void Attack()
    {
        //AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        //
        //animatorStateInfo.IsName("");
        //
        //if(animator.IsInTransition(0) || animatorStateInfo.IsName("Attack"))
        //{
        //    return;
        //}

        animator.SetTrigger("Attack");
    }
}
