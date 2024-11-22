using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private HealthPresenter _healthPresenter;

    private Rigidbody2D _body2D;

    public bool IsDead { get; private set; }

    private void Awake()
    {
        _healthPresenter.OnDead += OnDead;
        _body2D = GetComponent<Rigidbody2D>();
        IsDead = false;
    }

    private void OnDead()
    {
        gameObject.tag = "Untagged";
        _body2D.simulated = false;
        IsDead = true;
    }

    private void OnDestroy()
    {
        _healthPresenter.OnDead -= OnDead;
        Destroy(gameObject);
    }
}
