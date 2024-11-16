using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.Assertions;

public class HealthPresenter : MonoBehaviour
{
    [SerializeField] protected int _maxHealth;
    [SerializeField] protected float _invulnerabilityTime;
    [SerializeField] protected HealthView _healthView; // ?
    [SerializeField] protected float _knockBackDuration;
    [SerializeField] protected float _knockBackForce;
    [SerializeField] protected float _timeStopAfterTakeDamaage;

    protected HealthModel _healthModel;
    protected bool _canTakeDamage;
    protected KnockBack _knockBack;

    protected virtual void Awake()
    {
        _healthModel = new(_maxHealth, _invulnerabilityTime);
        _canTakeDamage = true;
        _knockBack = transform.parent.GetComponentInChildren<KnockBack>();
    }

    protected void Start()
    {
        _healthModel.RestoreHealth();
    }

    protected void OnEnable()
    {
        _healthModel.OnHealthChanged += UpdateView;
        _healthView.OnDamage += TakeDamage;
    }

    protected void OnDisable()
    {
        _healthModel.OnHealthChanged -= UpdateView;
        _healthView.OnDamage -= TakeDamage;
    }

    protected void UpdateView()
    {
        float percent = (float)_healthModel.CurrentHealth / _healthModel.MaxHealth;

        _healthView.ChangeView(percent);
    }

    public virtual void TakeDamage(int damage, Vector2 enemy)
    {
        if (_canTakeDamage)
        {
            _healthModel.CurrentHealth -= damage;
            _knockBack.DoKnockBack(enemy, _knockBackDuration, _knockBackForce);
        }

    }

    public void Heal(int amount)
    {
        _healthModel.CurrentHealth += amount;
    }


    
}
