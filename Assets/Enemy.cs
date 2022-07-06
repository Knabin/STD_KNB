using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    EnemyStateController stateController;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>(true);
        stateController = GetComponentInChildren<EnemyStateController>(true);

        if (stateController == null)
        {
            stateController = this.gameObject.AddComponent<EnemyStateController>();
        }

        // UniRX,
        // 생상성 향상
        // 설계도 좋아질 것 세련되짐, 포트폴리오도 좀 있어보임

        // 업데이트를 지켜보는 옵저버를 만들고,
        // 그 이벤트를 구독한다.
        this.UpdateAsObservable().Subscribe(_ => {
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("FindEnemy"))
            {
                Debug.LogError("I am Find Enemy");
                // 적을 찾아봄,
                animator.SetBool("IsFindEnemy", true);
            }
        }).AddTo(this);
    }


    private void Start()
    {
        stateController.Init((int)EnemyStateController.EnemyState.FIND_ENEMY);
    }

    private void Update()
    {
        if (stateController != null)
        {
            stateController.StateUpdate();
        }
    }
}