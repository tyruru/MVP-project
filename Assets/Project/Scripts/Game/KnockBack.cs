using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    private bool _isKnockedBack = false;
    private Rigidbody2D _body2D;

    private void Awake()
    {
        _body2D = GetComponentInParent<Rigidbody2D>();
    }

    public void DoKnockBack(Vector2 attackerPosition, float knockbackDuration, float knockBackForce)
    {
        if (!_isKnockedBack) 
        {
            Vector2 knockbackDirection = ((Vector2)transform.position - attackerPosition).normalized;

            StartCoroutine(KnockbackCoroutine(knockbackDirection, knockbackDuration, knockBackForce));
        }
    }

    private IEnumerator KnockbackCoroutine(Vector2 direction, float duration, float force)
    {
        _isKnockedBack = true;

        float timer = 0f;
        float initialForce = force;

        while (timer < duration)
        {
            _body2D.velocity = direction * initialForce * (1 - (timer / duration));

            timer += Time.deltaTime;  
            yield return null;
        }

        // Убедимся, что скорость вернулась в нормальное состояние
        _body2D.velocity = new Vector2(0, _body2D.velocity.y);
        _isKnockedBack = false;
    }
}
