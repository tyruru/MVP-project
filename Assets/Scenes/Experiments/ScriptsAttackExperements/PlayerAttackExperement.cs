using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackExperement : AbstractBehaviour
{
    public bool IsAttack;

    private void Start()
    {
        PlayerAttackView.OnAttack += Attack;
    }

    private void Attack(bool isAttack)
    {
        if(isAttack)
            StartAttack();
        else
            EndAttack();
    }

    public void StartAttack()
    {
        IsAttack = true;
    }

    public void EndAttack()
    {
        IsAttack = false;
    }
}