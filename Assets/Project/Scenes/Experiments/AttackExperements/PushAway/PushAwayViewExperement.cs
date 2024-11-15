using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAwayViewExperement : MonoBehaviour
{
    private PushAwayControllerExperement _test;

    private void Awake()
    {
        _test = GetComponentInChildren<PushAwayControllerExperement>();
    }

    public void KnockBack(Vector2 attackerPosition, float knockBackDuration, float knockBackForce)
    {
        _test.ApplyKnockback(attackerPosition, knockBackDuration, knockBackForce);
     }
}
