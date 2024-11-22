using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupBackground : MonoBehaviour
{
    [SerializeField] private Canvas canvas; // Canvas, которому нужно назначить камеру
    private Camera mainCamera; // Главная камера (та, которой управляет Cinemachine)

    private void Start()
    {
        // Если Canvas не задан, ищем его на текущем объекте
        if (canvas == null)
            canvas = GetComponent<Canvas>();

        // Находим главную физическую камеру
        mainCamera = Camera.main;

        // Проверяем, что режим Canvas правильный
        if (canvas.renderMode != RenderMode.ScreenSpaceCamera)
        {
            canvas.renderMode = RenderMode.ScreenSpaceCamera; // Устанавливаем нужный режим
        }

        // Назначаем физическую камеру, которой управляет Cinemachine
        canvas.worldCamera = mainCamera;
    }
}
