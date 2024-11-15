using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float _startSpeed = .6f;

    private float _currentSpeed;
    private Rigidbody2D body2d;

    public bool CanWalk;

    private void Start()
    {
        body2d = GetComponent<Rigidbody2D>();
        _currentSpeed = _startSpeed;
        CanWalk = true;
    }

    void Update()
    {
        if(CanWalk)
            body2d.velocity = new Vector2(transform.localScale.x, 0) * _currentSpeed;
    }

    public void NormilizeSpeed()
    {
        _currentSpeed = _startSpeed;
    }

    public void MultipliSpeed(float multiplier)
    {
        _currentSpeed *= multiplier;
    }

    public void Stop()
    {
        body2d.velocity = new Vector2(transform.localScale.x, 0);
    }
}
