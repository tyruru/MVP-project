using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FaceDirection : AbstractBehaviour
{
    private Direction _currentDirection;
    private InputAction _moveAction;
    private float _velX;
    private Transform _tranformParent;

    public enum Direction
    {
        Right = 1,
        Left = -1
    }

    private void Start()
    {
        _currentDirection = Direction.Right;
        _moveAction = _playerInput.actions.FindAction("Move");
        _tranformParent = transform.parent;
    }

    private void Update()
    {
        _velX = _moveAction.ReadValue<float>();

        if (_velX == 1)
            _currentDirection = Direction.Right;

        if (_velX == -1)
            _currentDirection = Direction.Left;

        _tranformParent.localScale = new Vector3((float)_currentDirection, 1, 1);
    }
}
