using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _waitSecondsAfterHit;

    private LookForward _lookForward;
    private MoveForward _moveForward;
    private RunForward _runForward;

    private void Awake()
    {
        _lookForward = GetComponent<LookForward>();
        _moveForward = GetComponent<MoveForward>();
        _runForward = GetComponent<RunForward>();
    }

    [SerializeField] private List<string> _targetTags;
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (_targetTags.Contains(target.transform.tag))
        {
            _moveForward.NormilizeSpeed();
            StartCoroutine(IdleCoroutine());
        }
    }

    private IEnumerator IdleCoroutine()
    {
        _moveForward.Stop();
        _moveForward.CanWalk = false;
        yield return new WaitForSeconds(_waitSecondsAfterHit);
        _moveForward.CanWalk = true;
    }
}
