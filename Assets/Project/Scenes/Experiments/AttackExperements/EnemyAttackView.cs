using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyAttackView : MonoBehaviour
{
    public static event Action<bool, float> OnAttack;

    private bool IsAttack = false;
    private FindTarget _findTarget;

    private void Start()
    {
        _findTarget = GetComponent<FindPlayer>();
    }

    private void Update()
    {
        if (_findTarget.CurrentTarget != null)
            StartAttack(10);
    }

    public void StartAttack(float value)
    {
        OnAttack?.Invoke(true, value);
    }

    public void EndAttack()
    {
        OnAttack?.Invoke(false, 0);
    }
}
