using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationManager : MonoBehaviour
{
    private Animator _animator;
    private BossAI _bossAI;
    private Death _death;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _bossAI = GetComponent<BossAI>();
        _death = GetComponent<Death>();
    }

    private void Update()
    {
        if(_death.IsDead)
        {
            ChangeAnimState(-1);
            return;
        }

        ChangeAnimState(0);
        if (_bossAI.IsAttack)
            ChangeAnimState(_bossAI.GetAttackId);

    }

    private void ChangeAnimState(int value)
    {
        _animator.SetInteger("AnimState", value);
    }
}
