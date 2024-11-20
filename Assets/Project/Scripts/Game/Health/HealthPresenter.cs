using System;
using UnityEngine;

public class HealthPresenter : MonoBehaviour
{
    [SerializeField] protected int _maxHealth;
    [SerializeField] protected float _invulnerabilityTime;
    [SerializeField] protected HealthView _healthView; // ?
    [SerializeField] protected float _knockBackDuration;
    [SerializeField] protected float _knockBackForce;
    [SerializeField] protected float _timeStopAfterTakeDamaage;

    protected HealthModel _healthModel;
    protected KnockBack _knockBack;

    protected bool _isDead;
    public bool IsDead => _isDead;

    public bool CanTakeDamage { get; protected set; }

    public bool IsDamage { get; protected set;}

    protected virtual void Awake()
    {
        _healthModel = new(_maxHealth, _invulnerabilityTime);
        CanTakeDamage = true;
        _knockBack = transform.parent.GetComponentInChildren<KnockBack>();
        _isDead = false;
    }

    protected void Start()
    {
        _healthModel.RestoreHealth();
    }

    protected void OnEnable()
    {
        _healthModel.OnHealthChanged += UpdateView;
        _healthView.OnDamage += TakeDamage;
        _healthView.OnEndTakeDamage += EndTakeDamage;
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
        if (CanTakeDamage)
        {
            _healthModel.CurrentHealth -= damage;

            if (_healthModel.CurrentHealth <= 0)
                Dead();

            else
            {
                _knockBack.DoKnockBack(enemy, _knockBackDuration, _knockBackForce);
                IsDamage = true;
            }
        }
    }

    private void EndTakeDamage()
    {
        IsDamage = false;
    }

    public void Heal(int amount)
    {
        _healthModel.CurrentHealth += amount;
    }

    private void Dead()
    {
        _isDead = true;
    }
    
}
