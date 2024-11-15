using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator _animator;
    private PlayerWalk _walk;
    private PlayerJump _jump;
    private CollisionState _collisionState;
    private PlayerFall _playerFall;
    private PlayerDash _playerDash;

    private PlayerAttack _playerAttack;

    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
        Transform parentTransform = transform.parent;

        _walk = parentTransform.GetComponentInChildren<PlayerWalk>();
        _jump = parentTransform.GetComponentInChildren<PlayerJump>();
        _playerDash = parentTransform.GetComponentInChildren<PlayerDash>();
        _playerFall = parentTransform.GetComponentInChildren<PlayerFall>();

        _collisionState = parentTransform.GetComponent<CollisionState>();
        _playerAttack = parentTransform.GetComponentInChildren<PlayerAttack>();
    }

    private void Update()
    {
        //standing
        //if(_collisionState.IsStanding)
            ChangeAnimState(1);
        //walk
        if (_walk.IsWalk && _collisionState.IsStanding)
            ChangeAnimState(2);
        //jump
        if (_jump.IsJumping)
            ChangeAnimState(3);
        //fall
        if (_playerFall.IsFall)
            ChangeAnimState(4);
        //attack
        if (_playerAttack.IsAttack)
            ChangeAnimState(_playerAttack.attackId);
        //dash
        if (_playerDash.IsDash)
            ChangeAnimState(4);
        
    }

    private void ChangeAnimState(int value)
    {
        _animator.SetInteger("AnimState", value);
    }
}
