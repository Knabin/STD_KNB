using System.Collections.Generic;
using UnityEngine;

public class FindEnemy : State
{
    public FindEnemy(StateController controller) : base(controller) {}
    Animator animator;

    public override void Enter()
    {
        if (controller)
        {
            animator = controller.gameObject.GetComponentInChildren<Animator>(true);
        }
    }

    public override void Exit()
    {
        Debug.Log("FindEnemy Exit");
    }

    public override void Update()
    {
        // 실제 코드 - 적을 찾는 루틴을 실행한다
        if (Input.GetKey(KeyCode.Space))
        {
            if (animator != null)
            {
                animator.SetBool("IsFindEnemy", true);
                controller.SetState((int)EnemyStateController.EnemyState.LOCOMOTION);
            }
        }
    }
}

public class Locomotion : State
{
    public Locomotion(StateController controller) : base(controller) {}
    Animator animator;

    public override void Enter()
    {
        if (controller)
        {
            animator = controller.gameObject.GetComponentInChildren<Animator>(true);
        }
    }

    public override void Exit()
    {
        Debug.Log("Locomotion Exit");
    }

    public override void Update()
    {
        // 실제 코드 - 타겟에게 가까이 가면 Attack으로 전환
        if (Input.GetKey(KeyCode.Space))
        {
            if (animator != null)
            {
                animator.SetTrigger("Attack");
                controller.SetState((int)EnemyStateController.EnemyState.ATTACK);
            }
        }
        // 타겟이 죽으면 다시 찾기
        if (Input.GetKey(KeyCode.Return))
        {
            if (animator != null)
            {
                animator.SetBool("IsFindEnemy", false);
                controller.SetState((int)EnemyStateController.EnemyState.FIND_ENEMY);
            }
        }
        // 내가 죽으면 죽기
        if (Input.GetKey(KeyCode.D))
        {
            if (animator != null)
            {
                animator.SetBool("IsDead", true);
                controller.SetState((int)EnemyStateController.EnemyState.DEAD);
            }
        }
    }
}

public class Attack : State
{
    public Attack(StateController controller) : base(controller) {}

    Animator animator;

    public override void Enter()
    {
        if (controller)
        {
            animator = controller.gameObject.GetComponentInChildren<Animator>(true);
        }
    }

    public override void Exit()
    {
        Debug.Log("Attack Exit");
    }

    public override void Update()
    {
        // 공격 처리 + 애니메이션이 끝나면
        if (Input.GetKey(KeyCode.Space))
        {
            controller.SetState((int)EnemyStateController.EnemyState.LOCOMOTION);
        }

        // 타겟이 죽으면 다시 찾기
        if (Input.GetKey(KeyCode.Return))
        {
            if (animator != null)
            {
                animator.SetBool("IsFindEnemy", false);
                controller.SetState((int)EnemyStateController.EnemyState.FIND_ENEMY);
            }
        }
        // 내가 죽으면 죽기
        if (Input.GetKey(KeyCode.D))
        {
            if (animator != null)
            {
                animator.SetBool("IsDead", true);
                controller.SetState((int)EnemyStateController.EnemyState.DEAD);
            }
        }
    }
}

public class Dead : State
{
    public Dead(StateController controller) : base(controller) {}

    public override void Enter()
    {
        Debug.Log("Dead Enter");
    }

    public override void Exit()
    {
        Debug.Log("Dead Exit");
    }

    public override void Update()
    {
        // Noting to do
    }
}