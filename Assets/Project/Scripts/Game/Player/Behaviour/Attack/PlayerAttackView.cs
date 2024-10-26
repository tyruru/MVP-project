using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackView : MonoBehaviour
{
    public static event Action<bool> OnAttack;

    private InputAction _attackAction;
    private InputAction _verticalAction;

    private bool IsAttack = false;

    private void Start()
    {
        _attackAction = GetComponent <PlayerInput>().actions.FindAction("Attack");
        // Нужен будет для атаки вверх/вниз
        _verticalAction = GetComponent<PlayerInput>().actions.FindAction("Vertical");
    }

    private void Update()
    {
        if (_attackAction.ReadValue<float>() == 1 && IsAttack == false)
        {
            IsAttack = true;
            StartAttack();
        }

        if (_attackAction.ReadValue<float>() == 0)
            IsAttack = false;
    }

    public void StartAttack()
    {
        OnAttack?.Invoke(true);
    }

    public void EndAttack()
    {
        OnAttack?.Invoke(false);
    }
}
