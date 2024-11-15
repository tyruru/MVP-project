using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    [SerializeField] private float _timeStopAfterHit;

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

    [SerializeField] private List<string> _targetTags;
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (_targetTags.Contains(target.tag))
        {
            _knockBack.DoKnockBack(target.transform.position, knockBackDuration, knockBackForce);
            StopTime.StopForSeconds(_timeStopAfterHit);
        }
    }
}
