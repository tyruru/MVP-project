using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrailTarget : MonoBehaviour
{
    public Transform target; // Цель, за которой следует след (например, босс)
    public float speed = 5f; // Скорость перемещения следа

    private Vector3 currentTargetPosition; // Текущая целевая точка следа

    void Start()
    {
        // Отвязываем след от родителя, чтобы он был независим
        transform.SetParent(null);

        // Устанавливаем начальную целевую позицию
        if (target != null)
        {
            currentTargetPosition = target.position;
        }
    }

    void Update()
    {
        if (target == null)
            return;

        // Постепенно движемся к текущей целевой точке
        transform.position = Vector3.MoveTowards(transform.position, currentTargetPosition, speed * Time.deltaTime);

        // Если след достиг текущей целевой точки, обновляем её
        if (Vector3.Distance(transform.position, currentTargetPosition) < 0.1f)
        {
            // Обновляем текущую целевую позицию на новую позицию цели
            currentTargetPosition = target.position;
        }
    }
}
