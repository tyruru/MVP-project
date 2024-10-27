using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public enum AttackId
    {
        Forward = 10,
        Down = 11,
        Up = 12
    }

    public bool IsAttack;
    public int attackId = 10;

    private void Start()
    {
        PlayerAttackView.OnAttack += Attack;
    }

    private void Attack(bool isAttack, float value)
    {
        if ((int)value == 0)
            attackId = (int)AttackId.Forward;

        if ((int)value == -1)
            attackId = (int)AttackId.Down;

        if ((int)value == 1)
            attackId = (int)AttackId.Up;

        IsAttack = isAttack;
    }
}
