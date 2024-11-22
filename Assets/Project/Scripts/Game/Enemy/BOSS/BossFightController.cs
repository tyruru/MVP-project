using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightController : MonoBehaviour
{
    [SerializeField] private Collider2D _enterCollider, _exitCollider;

    [SerializeField] private GameObject _object;

    private void Awake()
    {
        _enterCollider.enabled = false;
        _exitCollider.enabled = true;

        BossAI.OnFightStart += FightStart;
        BossAI.OnFightEnd += FightEnd;
    }

    private void FightEnd()
    {
        if(_exitCollider != null)
            _exitCollider.enabled = false;
    }

    private void FightStart()
    {
        _enterCollider.enabled = true;
        _object.tag = "Untagged";
    }

    private void OnDestroy()
    {
        BossAI.OnFightStart -= FightStart;
        BossAI.OnFightEnd -= FightEnd;
    }
}
