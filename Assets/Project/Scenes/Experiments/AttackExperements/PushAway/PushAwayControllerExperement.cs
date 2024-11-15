using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAwayControllerExperement : MonoBehaviour
{
    private bool _isKnockedBack = false;
    private Rigidbody2D _body2D;

    private void Awake()
    {
        _body2D = GetComponentInParent<Rigidbody2D>();
    }

    public void ApplyKnockback(Vector2 attackerPosition, float knockbackDuration, float knockBackForce)
    {
        if (!_isKnockedBack) // Проверяем, чтобы не было нескольких отталкиваний
        {
            Vector2 knockbackDirection = ((Vector2)transform.position - attackerPosition).normalized;

            Debug.Log("knockBack: " + knockbackDirection);

            StartCoroutine(KnockbackCoroutine(knockbackDirection, knockbackDuration, knockBackForce));
        }
    }

    private IEnumerator KnockbackCoroutine(Vector2 direction, float duration, float force)
    {
        _isKnockedBack = true;

        float timer = 0f;
        float initialForce = force;

        // Постепенное отталкивание с уменьшением силы
        while (timer < duration)
        {
            // Применение отталкивающей силы
            _body2D.velocity = new Vector2(direction.x * initialForce * (1 - (timer / duration)), _body2D.velocity.y);

            timer += Time.deltaTime;  // Инкрементируем таймер
            yield return null;  // Ждем следующего кадра
        }

        // Убедимся, что скорость вернулась в нормальное состояние
        _body2D.velocity = new Vector2(0, _body2D.velocity.y);
        _isKnockedBack = false;
    }
}
