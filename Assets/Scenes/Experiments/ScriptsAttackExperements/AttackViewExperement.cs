using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackViewExperement : MonoBehaviour
{
    private KnockBack _knockBack;

    private void Awake()
    {
        _knockBack = GetComponentInChildren<KnockBack>();
    }

    [SerializeField] private string _targetTag;
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == _targetTag)
        {
            _knockBack.DoKnockBack(target.transform.position, 0.5f, 5f);
        }
    }
}
