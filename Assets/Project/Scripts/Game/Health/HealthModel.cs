using System;
using UnityEngine;


public class HealthModel 
{
    public event Action OnHealthChanged;

    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public int CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = value;
            OnHealthChanged?.Invoke();
        }
    }

    public int MaxHealth
    {
        get => _maxHealth;
        set
        {
            _maxHealth = value;
            OnHealthChanged?.Invoke();
        }
    }

    public void RestoreHealth()
    {
        CurrentHealth = _maxHealth;
    }
}
