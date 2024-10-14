using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionState : MonoBehaviour
{
    [SerializeField] private LayerMask _collisionLayer;
    [SerializeField] private float _collisionRadius = 1f;
    [SerializeField] private Vector2 _bottomPosition = Vector2.zero;
    [SerializeField] private Color _debugCollisionColor;

    public bool IsStanding;

    private void FixedUpdate()
    {
        Vector2 pos = _bottomPosition;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        IsStanding = Physics2D.OverlapCircle(pos, _collisionRadius, _collisionLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _debugCollisionColor;

        Vector2 pos = _bottomPosition;
        pos.x += transform.position.x;
        pos.y += transform.position.y;

        Gizmos.DrawWireSphere(pos, _collisionRadius);
    }
}
