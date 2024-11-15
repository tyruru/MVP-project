using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackView : MonoBehaviour
{
    public static event Action<bool, float> OnAttack;

    private InputAction _attackAction;
    private InputAction _verticalAction;

    private bool IsAttack = false;

    private void Start()
    {
        _attackAction = GetComponent <PlayerInput>().actions.FindAction("Attack");
        // Нужен для атаки вверх/вниз
        _verticalAction = GetComponent<PlayerInput>().actions.FindAction("Vertical");
    }

    private void Update()
    {
        if (_attackAction.ReadValue<float>() == 1 && IsAttack == false)
        {
            IsAttack = true;
            StartAttack(_verticalAction.ReadValue<float>());
        }

        if (_attackAction.ReadValue<float>() == 0)
            IsAttack = false;
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
