using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthView : HealthView
{
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
                TakeDamage(1, target.transform.position);
    }

    public override void ChangeView(float hpPercent)
    {
        Debug.Log("View: Percent is:" + hpPercent);
        _hpBar.value = hpPercent;
    }
}
