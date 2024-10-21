using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator _animator;
    private PlayerWalk _walk;
    private PlayerJump _jump;
    private CollisionState _collisionState;
    private PlayerFall _playerFall;

    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
        Transform parentTransform = transform.parent;
        _walk = parentTransform.GetComponentInChildren<PlayerWalk>();
        _jump = parentTransform.GetComponentInChildren<PlayerJump>();
        _collisionState = parentTransform.GetComponent<CollisionState>();
        _playerFall = parentTransform.GetComponentInChildren<PlayerFall>();
    }

    private void Update()
    {
        //standing
        if(_collisionState.IsStanding)
            ChangeAnimState(1);
        //walk
        if (_walk.IsWalk)
            ChangeAnimState(2);
        //jump
        if (_jump.IsJumping)
            ChangeAnimState(3);
        //fall
        if (_playerFall.IsFall)
            ChangeAnimState(4);

    }

    private void ChangeAnimState(int value)
    {
        _animator.SetInteger("AnimState", value);
    }
}
