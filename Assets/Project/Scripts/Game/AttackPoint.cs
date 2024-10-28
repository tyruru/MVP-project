using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    private KnockBack _knockBack;

    public float knockBackForce;
    public float knockBackDuration;

    public void SetKnockBackForce(float force)
    {
        knockBackForce = force;
    }

    private void Awake()
    {
        _knockBack = transform.parent.GetComponentInChildren<KnockBack>();
        knockBackForce = 8;
        knockBackDuration = 0.3f;
    }

    [SerializeField] private string _targetTag;
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == _targetTag)
        {
            _knockBack.DoKnockBack(target.transform.position, knockBackDuration, knockBackForce);
        }
    }
}
