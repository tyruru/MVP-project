using System;
using UnityEngine;

public class PlayerFall : AbstractBehaviour
{
    [SerializeField] private float _fallMultiplier = 3f;
    [SerializeField] private float _fallSmooth = 2f;

    private float _currentFallMultiplier;
    private Vector2 _vecGravity;
    private PlayerJump _testJump;

    public bool IsFall;


    private void Start()
    {
        _vecGravity = new Vector2(0, -Physics.gravity.y);
        _currentFallMultiplier = _fallMultiplier;
        _testJump = GetComponent<PlayerJump>();
    }

    private void Update()
    {
        if (_body2D.velocity.y < 0 && !_collisionState.IsStanding)
        {
            Fall();
            IsFall = true;
        }
        else
        {
            IsFall = false;
        }

        if (_testJump.IsFullJump)
            _currentFallMultiplier = Time.deltaTime + _fallSmooth;

        if (_collisionState.IsStanding)
            _currentFallMultiplier = _fallMultiplier;
    }

    private void Fall()
    {
        _body2D.velocity -= _vecGravity * _currentFallMultiplier * Time.deltaTime;
    }
}
