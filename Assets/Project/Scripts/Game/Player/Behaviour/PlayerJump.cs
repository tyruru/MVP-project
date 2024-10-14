using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerJump : AbstractBehaviour
{
    [SerializeField] private float _jumpTime;
    [SerializeField] private float _jumpSpeed = 8f;
    [SerializeField] private float _fallMultiplier = 1f;
    [SerializeField] private float _jumpMultilpier = 1.2f;

    private InputAction _jumpAction;
    private Vector2 _vecGravity;


    public bool IsJumping;
    float jumpCounter;


    void Start()
    {
        _jumpAction = _playerInput.actions.FindAction("Jump");
        _vecGravity = new Vector2(0, -Physics.gravity.y);
    }

    private void Update()
    {
        if (_jumpAction.ReadValue<float>() == 1 && _collisionState.IsStanding)
        {
            OnJump();
            IsJumping = true;
        }

        if(_jumpAction.ReadValue<float>() == 0)
        {
            IsJumping = false;
        }

        if (_body2D.velocity.y < 0)
        {
            _body2D.velocity -= _vecGravity * _fallMultiplier * Time.deltaTime;
        }

        if(_body2D.velocity.y > 0 && IsJumping)
        {
            jumpCounter += Time.deltaTime;

            if (jumpCounter > _jumpTime)
                IsJumping = false;

            _body2D.velocity += _vecGravity * _jumpMultilpier * Time.deltaTime;
        }
    }

    private void OnJump()
    {
        float velx = _body2D.velocity.x;
        _body2D.velocity = new Vector2(velx, _jumpSpeed);
        jumpCounter = 0f;
    }
}
