using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackViewExperement : MonoBehaviour
{
    private PushAwayViewExperement _pushView;

    private void Awake()
    {
        _pushView = GetComponentInParent<PushAwayViewExperement>();
    }

    [SerializeField] private string _targetTag;
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == _targetTag)
        {
            Debug.Log(_targetTag + " finded");
            _pushView.KnockBack(target.transform.position, 0.5f, 5f);
        }
    }
}
