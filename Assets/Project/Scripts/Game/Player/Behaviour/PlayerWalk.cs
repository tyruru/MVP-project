using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerWalk : AbstractBehaviour
{
    [SerializeField] private float _speed = 4f;

    private InputAction _moveAction;
    private float velX;
    private CollisionState _collisionState;

    public bool IsWalk;

    public static event Action OnWalk;

    private Coroutine _walkSoundCoroutine;

    void Start()
    {
        _moveAction = _playerInput.actions.FindAction("Horizontal");
        _collisionState = transform.parent.GetComponent<CollisionState>();
    }

    void Update()
    {
        if (Time.timeScale == 0f)
            return;

         velX = _moveAction.ReadValue<float>() * _speed;

        _body2D.velocity = new Vector2(velX, _body2D.velocity.y);

        if (velX != 0)
        {
            IsWalk = true;

            if (_walkSoundCoroutine == null && _collisionState.IsStanding) 
                _walkSoundCoroutine = StartCoroutine(WalkSoundRoutine());
        }
        else
            IsWalk = false;
    }

    private void WalkSound()
    {
        OnWalk?.Invoke();
    }

    private IEnumerator WalkSoundRoutine()
    {
        WalkSound(); 
        yield return new WaitForSeconds(0.4f); 
        
        _walkSoundCoroutine = null;
    }
}
