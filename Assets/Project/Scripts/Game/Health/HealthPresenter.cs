using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.Assertions;

public class HealthPresenter : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _invulnerabilityTime;
    [SerializeField] private HealthView _healthView; // ?
    [SerializeField] private float _knockBackDuration;
    [SerializeField] private float _knockBackForce;
    [SerializeField] private float _timeStopAfterTakeDamaage;

    private HealthModel _healthModel;
    private bool _canTakeDamage;
    private KnockBack _knockBack;

    private void Awake()
    {
        _healthModel = new(_maxHealth, _invulnerabilityTime);
        _canTakeDamage = true;
        Assert.IsNotNull(_healthView, "[PlayerPresenter] PlayerView is required");
        _knockBack = transform.parent.GetComponentInChildren<KnockBack>();
    }

    private void OnEnable()
    {
        _healthModel.OnHealthChanged += UpdateView;
        _healthView.OnDamage += TakeDamage;
    }

    private void OnDisable()
    {
        _healthModel.OnHealthChanged -= UpdateView;
        _healthView.OnDamage -= TakeDamage;
    }

    private void Start()
    {
        _healthModel.RestoreHealth();
    }

    private void UpdateView()
    {
        float percent = (float)_healthModel.CurrentHealth / _healthModel.MaxHealth;

        _healthView.ChangeView(percent);
    }

    public void TakeDamage(int damage, Collision2D enemy)
    {
        if (_canTakeDamage)
        {
            _healthModel.CurrentHealth -= damage;
            _canTakeDamage = false;
            StartCoroutine(InvulnerabilityCoroutine());
            _knockBack.DoKnockBack(enemy.transform.position, _knockBackDuration, _knockBackForce);
            StopTime.StopForSeconds(_timeStopAfterTakeDamaage);
        }

    }

    public void Heal(int amount)
    {
        _healthModel.CurrentHealth += amount;
    }


    private IEnumerator InvulnerabilityCoroutine()
    {
        yield return new WaitForSecondsRealtime(_healthModel.InvulnerabilityTime);
        _canTakeDamage = true;
    }
}
