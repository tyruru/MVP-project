using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    private KnockBack _knockBack;

    private void Awake()
    {
        _knockBack = transform.parent.GetComponentInChildren<KnockBack>();
    }

    [SerializeField] private string _targetTag;
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == _targetTag)
        {
            _knockBack.DoKnockBack(target.transform.position, 0.3f, 8f);
        }
    }
}
