using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthView : MonoBehaviour
{ 
    public event Action<int> OnDamage;

    [SerializeField] private string[] _targets;

    private void OnCollisionEnter2D(Collision2D target)
    {
        foreach (var tag in _targets)
            if (target.gameObject.CompareTag(tag))
                OnDamage?.Invoke(5);
    }


    public void ChangeView()
    {
        Debug.Log("View Changed");
    }

}
