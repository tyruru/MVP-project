using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public bool IsAttack;

    private void Start()
    {
        PlayerAttackView.OnAttack += Attack;
    }

    private void Attack(bool isAttack)
    {
        IsAttack = isAttack;
    }
}
