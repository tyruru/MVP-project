using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFaceDirection : MonoBehaviour
{
    private Transform _playerTransform;
    private float _x;
    private float _y;

    private void Awake()
    {
        _playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _x = transform.localScale.x;
        _y = transform.localScale.y;
    }

    private void Update()
    {
        float difference = _playerTransform.position.x - transform.position.x;


        if (difference > 0)
        {
            transform.localScale = new Vector3(_x, _y, 0);
            Debug.Log("RIGHT");
        }

        if (difference < 0)
        {
            transform.localScale = new Vector3(-_x, _y, 0);
            Debug.Log("LEFT");

        }
    }
}
