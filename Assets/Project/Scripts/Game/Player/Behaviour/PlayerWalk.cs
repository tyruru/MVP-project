using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalk : AbstractBehaviour
{
    [SerializeField] private float _speed = 4f;

    private InputAction _moveAction;
    private float velX;

    public bool IsWalk;

    void Start()
    {
        _moveAction = _playerInput.actions.FindAction("Horizontal");
    }

    void Update()
    {
        if (Time.timeScale == 0f)
            return;

         velX = _moveAction.ReadValue<float>() * _speed;

        _body2D.velocity = new Vector2(velX, _body2D.velocity.y);

        if (velX != 0)
            IsWalk = true;
        else
            IsWalk = false;
    }

}
