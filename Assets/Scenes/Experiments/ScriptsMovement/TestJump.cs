using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestJump : AbstractBehaviour
{
    [SerializeField] private float _jumpTime = 0.6f;
    [SerializeField] private float _jumpSpeed = 10f;
    [SerializeField] private float _jumpMultilpier = 2f;
    [SerializeField] private int _jumpCount = 1;
    [SerializeField] private float _fullJumpSmooth = 0.7f;

    private InputAction _jumpAction;
    private Vector2 _vecGravity;
    private float _currentJumpTime;
    private float _currentJumpCount;

    [HideInInspector] public bool IsJumping;
    [HideInInspector] public bool IsFullJump;


    void Start()
    {
        _jumpAction = _playerInput.actions.FindAction("Jump");
        _vecGravity = new Vector2(0, -Physics.gravity.y);
    }

    private void Update()
    {
        // Если приземлились
        if(_collisionState.IsStanding)
        {
            IsFullJump = false;
            IsJumping = false;
            _currentJumpCount = _jumpCount;
        }

        // Press Button
        if (_jumpAction.ReadValue<float>() == 1 && _currentJumpCount > 0)
        {
            OnJump();
            _currentJumpTime = 0f;
            IsJumping = true;
            _currentJumpCount--;
        }

        // Button up
        if (_jumpAction.ReadValue<float>() == 0)
            IsJumping = false;
        
        if (!IsJumping || IsFullJump)
        {
            // Резкая остановка прыжка
            if (_body2D.velocity.y > 0 && !IsFullJump)
                _body2D.velocity = new Vector2(_body2D.velocity.x, 0);

            // Плавная остановка прыжка
            if (_body2D.velocity.y > 0 && IsFullJump)
                _body2D.velocity = new Vector2(_body2D.velocity.x, _body2D.velocity.y * _fullJumpSmooth);
        }

        // Smooth
        if (_body2D.velocity.y > 0)
        {
            _currentJumpTime += Time.deltaTime;

            if (_currentJumpTime >= _jumpTime)
                IsFullJump = true;

            float t = _currentJumpTime / _jumpTime;
            float currentJumpM = _jumpMultilpier;

            if (t > 0.5f)
                currentJumpM = _jumpMultilpier * (1 - t);

            _body2D.velocity += _vecGravity * currentJumpM * Time.deltaTime;
        }
    }

    private void OnJump()
    {
        float velx = _body2D.velocity.x;
        _body2D.velocity = new Vector2(velx, _jumpSpeed);
    }
}
