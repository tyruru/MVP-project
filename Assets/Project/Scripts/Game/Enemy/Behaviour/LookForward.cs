using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForward : MonoBehaviour
{
    [SerializeField] private Transform _sightStart, _sightEnd;
    [SerializeField] private string layer = "Solid";
    [SerializeField] private bool _needsCollision = true;

    private bool collision;

    void Update()
    {
        collision = Physics2D.Linecast(_sightStart.position, _sightEnd.position, 1 << LayerMask.NameToLayer(layer));

        Debug.DrawLine(_sightStart.position, _sightStart.position, Color.green);

        if (collision == _needsCollision)
        {
            transform.localScale = new Vector3(transform.localScale.x == 1 ? -1 : 1, 1, 1);
        }
    }
}
