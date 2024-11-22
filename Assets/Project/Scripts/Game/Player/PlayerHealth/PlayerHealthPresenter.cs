using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthPresenter : HealthPresenter
{
    private PlayerDash _dash;
    private TakeDamageEffect _damageEffect;

    protected override void Awake()
    {
        base.Awake();

        _dash = transform.parent.GetComponentInChildren<PlayerDash>();
        _damageEffect = FindObjectOfType<TakeDamageEffect>();
    }

    public override void TakeDamage(int damage, Vector2 enemy)
    {
        base.TakeDamage(damage, enemy);

        if (IsDead)
        {
            Debug.Log("IS DEAD");
            FindObjectOfType<PlayerInputToggler>().DisableObjects();
            FindObjectOfType<PauseButtonCommand>().HideButton();
            GameObject.FindGameObjectWithTag("DeadMenu").GetComponent<DeadMenu>().Execute(); ; 
            return;
        }

        if (CanTakeDamage)
        {
            CanTakeDamage = false;
            StopTime.StopForSeconds(_timeStopAfterTakeDamaage);
            StartCoroutine(InvulnerabilityCoroutine());
            _dash.RestoreDash();
            if (_damageEffect != null)
            {
                _damageEffect.TriggerDamageEffect();
                Debug.Log("TriggerDamage");
            }
        }

    }

    private IEnumerator InvulnerabilityCoroutine()
    {
        yield return new WaitForSecondsRealtime(_healthModel.InvulnerabilityTime);
        CanTakeDamage = true;
    }
}
