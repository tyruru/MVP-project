using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthPresenter : HealthPresenter
{
    private PlayerDash _dash;

    protected override void Awake()
    {
        base.Awake();

        _dash = transform.parent.GetComponentInChildren<PlayerDash>();
    }

    public override void TakeDamage(int damage, Vector2 enemy)
    {
        base.TakeDamage(damage, enemy);

        if (_canTakeDamage)
        {
            _canTakeDamage = false;
            StopTime.StopForSeconds(_timeStopAfterTakeDamaage);
            StartCoroutine(InvulnerabilityCoroutine());
            _dash.RestoreDash();
        }
    }

    private IEnumerator InvulnerabilityCoroutine()
    {
        yield return new WaitForSecondsRealtime(_healthModel.InvulnerabilityTime);
        _canTakeDamage = true;
    }
}
