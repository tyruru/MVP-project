using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerDash : AbstractBehaviour
{
    InputAction _dashAction;

    private bool _isDash;
    public bool IsDash => _isDash;

    private bool _canDash;
    private KnockBack _knockBack;

    [SerializeField] private float _duration;
    [SerializeField] private float _force;

    private float _timer;

    private void Start()
    {
        _dashAction = _playerInput.actions.FindAction("Dash");
        _knockBack = transform.parent.GetComponentInChildren<KnockBack>();
    }

    private void Update()
    {
        if (_dashAction.ReadValue<float>() == 1 && !_isDash && _canDash)
            StartDash();

        if (_timer > _duration)
            _isDash = false;

        // при касании земли перезаряжаем рывок
        if (_collisionState.IsStanding)
            RestoreDash();

        _timer += Time.deltaTime;
    }

    private void StartDash()
    {
        _isDash = true;
        _canDash = false;
        _knockBack.DoKnockBackX(_duration, _force);
        _timer = 0f;
    }

    public void RestoreDash()
    {
        _canDash = true;
    }

}
