using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FindTarget : MonoBehaviour
{
    [SerializeField] protected float _width;
    [SerializeField] protected float _height;
    [SerializeField] protected Color _debugColor;
    [SerializeField] protected Vector2 _pos = Vector2.zero;
    [SerializeField] protected string _targetTag;

    public Collider2D CurrentTarget { get; protected set; }

    protected virtual void Update()
    {
        List<Collider2D> targets = FindAllTargets();

        if (targets.Count > 1)
            FindClosestTarget(targets);

        if (targets.Count == 1)
            CurrentTarget = targets[0];

        if (targets.Count == 0)
            CurrentTarget = null;

        //Debug.Log($"current target \"{_targetTag}\": " + CurrentTarget);
    }

    protected List<Collider2D> FindAllTargets()
    {
        var pos = _pos;
        pos.x *= transform.localScale.x;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        Vector2 size = new Vector2(_width, _height);

        var allTargets = Physics2D.OverlapBoxAll(pos, size, 0);

        List<Collider2D> targets = new();

        foreach (var target in allTargets)
        {
            if (target.CompareTag(_targetTag))
                targets.Add(target);
        }

        return targets;
    }

    protected void FindClosestTarget(List<Collider2D> targets)
    {
        if(targets.Count > 0)
            CurrentTarget = targets[0];

        foreach(var target in targets)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            float distanceToCurrentTarget = Vector3.Distance(transform.position, CurrentTarget.transform.position);

            if (distanceToTarget < distanceToCurrentTarget)
                CurrentTarget = target;
        }
    }

    protected void OnDrawGizmos()
    {
        var pos = _pos;
        pos.x *= transform.localScale.x;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        Gizmos.color = _debugColor;

        Gizmos.DrawWireCube(pos, new Vector2(_width, _height));
    }

}
