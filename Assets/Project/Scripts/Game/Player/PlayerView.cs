using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerView : MonoBehaviour
{
    private Rigidbody2D _body2d;

    private void Awake()
    {
        _body2d = GetComponent<Rigidbody2D>();
    }


}
