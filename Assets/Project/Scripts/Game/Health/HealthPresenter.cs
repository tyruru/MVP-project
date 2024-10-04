using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.Assertions;

public class HealthPresenter : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private HealthView _healthView; // ?
    private HealthModel _healthModel;

    private void Awake()
    {
        _healthModel = new();

        Assert.IsNotNull(_healthView, "[PlayerPresenter] PlayerView is required");
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
        IncrementMaxHealth(_maxHealth);
        _healthModel.RestoreHealth();
    }

    private void UpdateView()
    {
        Debug.Log("Presenter: current hp is " + _healthModel.CurrentHealth);
        _healthView.ChangeView();
    }

    public void TakeDamage(int damage)
    {
        _healthModel.CurrentHealth -= damage;
    }

    public void Heal(int amount)
    {
        _healthModel.CurrentHealth += amount;
    }

    public void IncrementMaxHealth(int amount)
    {
        _healthModel.MaxHealth += amount;
    }

    public void DecrementMaxHp(int amount)
    {
        _healthModel.MaxHealth -= amount;
    }
}
