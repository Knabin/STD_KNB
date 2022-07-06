using System.Collections.Generic;
using UnityEngine;

public class FindEnemy : State
{
    Animator animator;

    public override void Enter()
    {
        if (rootObject)
        {
            animator = rootObject.GetComponentInChildren<Animator>(true);
        }
    }

    public override void Exit()
    {
        // 
    }

    public override void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (animator != null)
            {
                animator.SetBool("IsFindEnemy", true);
            }
        }
    }
}

public class Locomotion : State
{
    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        // 가까이 가면 Attack으로 전환
    }
}

public class Attack : State
{
    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        // 거리가 멀어지면 Locomotion
        // 적이 죽으면 Dead로
    }
}

public class Dead : State
{
    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void Update()
    {
        // Noting to do
    }
}