using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalk : AbstractBehaviour
{
    [SerializeField] private float _speed = 4f;

    private InputAction _moveAction;

    void Start()
    {
        _moveAction = _playerInput.actions.FindAction("Move");
    }

    void Update()
    {
        float velX = _moveAction.ReadValue<float>() * _speed;

        _body2D.velocity = new Vector2(velX, _body2D.velocity.y);
    }

}
