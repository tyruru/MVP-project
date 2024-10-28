using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerDash : AbstractBehaviour
{
    InputAction _dashAction;

    private bool _isDash;
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
            _canDash = true;

        _timer += Time.deltaTime;
    }

    private void StartDash()
    {
        _isDash = true;
        _canDash = false;
        _knockBack.DoKnockBackX(_duration, _force);
        _timer = 0f;
        //StartCoroutine(DashCoroutine());
    }

    //private IEnumerator DashCoroutine()
    //{
    //    float timer = 0f;
    //    float velX = transform.parent.localScale.x;
    //    float velY = transform.parent.localScale.y;

    //    Debug.Log("velx: " + velX);

    //    while (timer < _duration)
    //    {
    //        _body2D.velocity = new Vector2(velX * _force * (1 - (timer / _duration)), 0);

    //        timer += Time.deltaTime;
    //        yield return null;
    //    }

    //    // Убедимся, что скорость вернулась в нормальное состояние
    //    _body2D.velocity = new Vector2(0, _body2D.velocity.y);
    //    _isDash = false;
    //}
}
