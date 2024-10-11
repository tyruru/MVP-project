using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerJump : AbstractBehaviour
{
    [SerializeField] private float _jumpSpeed = 8f;

    private InputAction _jumpAction;

    void Start()
    {
        _jumpAction = _playerInput.actions.FindAction("Jump");
    }

    private void Update()
    {
        if (_jumpAction.ReadValue<float>() == 1)
        {
            OnJump();
        }
    }

    private void OnJump()
    {
        float velx = _body2D.velocity.x;
        _body2D.velocity = new Vector2(velx, _jumpSpeed);
    }
}
