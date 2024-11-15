using UnityEngine.UI;
using UnityEngine;
using System;

public class HealthView : MonoBehaviour
{ 
    public event Action<int, Collision2D> OnDamage;

    private Slider _hpBar;
    [SerializeField] private string[] _targets;

    private void Awake()
    {
        _hpBar = GameObject.FindGameObjectWithTag("playerHpSlider").GetComponent<Slider>();
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        foreach (var tag in _targets)
            if (target.gameObject.CompareTag(tag))
                OnDamage?.Invoke(1, target);
    }


    public void ChangeView(float hpPercent)
    {
        Debug.Log("View: Percent is:" + hpPercent);
        _hpBar.value = hpPercent;
    }

}
