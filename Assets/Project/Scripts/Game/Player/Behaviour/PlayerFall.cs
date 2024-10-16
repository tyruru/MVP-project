using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : AbstractBehaviour
{
    [SerializeField] private float _fallMultiplier = 3f;
    [SerializeField] private float _fallSmooth = 2f;

    private float _currentFallMultiplier;
    private Vector2 _vecGravity;
    private PlayerJump _testJump;

    private void Start()
    {
        _vecGravity = new Vector2(0, -Physics.gravity.y);
        _currentFallMultiplier = _fallMultiplier;
        _testJump = GetComponent<PlayerJump>();
    }

    private void Update()
    {
        if (_body2D.velocity.y < 0)
            OnFall();

        if (_testJump.IsFullJump)
            _currentFallMultiplier = Time.deltaTime + _fallSmooth;

        if (_collisionState.IsStanding)
            _currentFallMultiplier = _fallMultiplier;


    }

    private void OnFall()
    {
        _body2D.velocity -= _vecGravity * _currentFallMultiplier * Time.deltaTime;
    }
}
