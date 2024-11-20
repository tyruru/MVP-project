using UnityEngine;
using System;

public class HealthView : MonoBehaviour
{ 
    public event Action<int, Vector2> OnDamage;
    public event Action OnEndTakeDamage;

    public virtual void ChangeView(float hpPercent)
    {
        Debug.Log("View: Percent is:" + hpPercent);
    }

    public void TakeDamage(int damage, Vector2 target)
    {
        OnDamage?.Invoke(damage, target);
    }

    public void EndTakeDamage()
    {
        OnEndTakeDamage?.Invoke();
    }
}
