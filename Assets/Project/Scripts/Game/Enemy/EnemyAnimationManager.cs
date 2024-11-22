using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{
    private Animator _animator;
    private Death _death;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _death = GetComponent<Death>();
    }

    private void Update()
    {
        if (_death.IsDead)
            ChangeAnimState(-1);
    }

    private void ChangeAnimState(int value)
    {
        _animator.SetInteger("AnimState", value);
    }
}
