using System;
using UnityEngine;


public class HealthModel 
{
    public event Action OnHealthChanged;

    public HealthModel(int maxHealth, float invulnerabilityTime)
    {
        _maxHealth = maxHealth;
        _invulnerabilityTime = invulnerabilityTime;
        _currentHealth = maxHealth;
    }

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

    private int _maxHealth;
    public int MaxHealth
    {
        get => _maxHealth;
        set
        {
            _maxHealth = value;
            OnHealthChanged?.Invoke();
        }
    }

    private float _invulnerabilityTime;
    public float InvulnerabilityTime => _invulnerabilityTime;

    public void RestoreHealth()
    {
        CurrentHealth = _maxHealth;
    }
}
