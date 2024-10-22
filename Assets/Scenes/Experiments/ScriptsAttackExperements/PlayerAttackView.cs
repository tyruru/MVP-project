using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayerAttackView : AbstractBehaviour
{
    public static event Action<bool> OnAttack;

    private InputAction _attackAction;

    private bool IsAttack = false;

    private void Start()
    {
        _attackAction = _playerInput.actions.FindAction("Attack");
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
