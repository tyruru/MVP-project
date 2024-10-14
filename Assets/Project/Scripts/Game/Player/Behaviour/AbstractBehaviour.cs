using Zenject;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

public abstract class AbstractBehaviour : MonoBehaviour
{
    protected Rigidbody2D _body2D;
    protected PlayerInput _playerInput;
    protected CollisionState _collisionState;

    protected virtual void Awake()
    {
        _body2D = GetComponentInParent<Rigidbody2D>();
        Assert.IsNotNull(_body2D, "[Body2d] is missed");
        _playerInput = GetComponentInParent<PlayerInput>();
        Assert.IsNotNull(_playerInput, "Player input is null");
        _collisionState = GetComponentInParent<CollisionState>();
        Assert.IsNotNull(_playerInput, "Collision state is null");
    }


}
