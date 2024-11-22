using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SetupCinemachineBounds : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera; 
    private Collider2D _boundingCollider; 

    private void Start()
    {
        _virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        _boundingCollider = GameObject.FindGameObjectWithTag("BoundCollider").GetComponent<Collider2D>();

        if (_virtualCamera == null || _boundingCollider == null)
        {
            Debug.LogError("Необходимо указать виртуальную камеру и Bounding Collider!");
            return;
        }

        var confiner = _virtualCamera.gameObject.GetComponent<CinemachineConfiner2D>();

        // Указываем границы для CinemachineConfiner
        confiner.m_BoundingShape2D = _boundingCollider;

        //// Включаем обновление границ (если это необходимо)
        //confiner.InvalidatePathCache();

        Debug.Log("Bound Collider успешно добавлен к Cinemachine!");
    }
}
