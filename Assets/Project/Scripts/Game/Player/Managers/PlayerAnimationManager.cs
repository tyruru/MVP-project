using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator _animator;
    private PlayerWalk _walk;
    private PlayerJump _jump;
    

    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
        Transform parentTransform = transform.parent;
        _walk = parentTransform.GetComponentInChildren<PlayerWalk>();
        _jump = parentTransform.GetComponentInChildren<PlayerJump>();
    }

    private void Update()
    {
        
    }

    private void ChangeAnimState(int value)
    {

    }
}
