using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    private bool _isKnockedBack = false;
    private Rigidbody2D _body2D;
    private Coroutine _coroutine;

    private void Awake()
    {
        _body2D = GetComponentInParent<Rigidbody2D>();
    }

    public void DoKnockBack(Vector2 attackerPosition, float knockbackDuration, float knockBackForce)
    {
        Vector2 knockbackDirection = ((Vector2)transform.position - attackerPosition).normalized;

        Test(knockbackDirection, knockbackDuration, knockBackForce);
    }

    public void DoKnockBackX(float knockbackDuration, float knockBackForce)
    {
        float velX = transform.parent.localScale.x;
        Vector2 knockbackDirection = new Vector2(velX, 0);

        Test(knockbackDirection, knockbackDuration, knockBackForce);
    }

    private void Test(Vector2 direction, float duration, float force)
    {
        if (_isKnockedBack)
        {
            StopCoroutine(_coroutine);
            _isKnockedBack = false;
            _body2D.velocity = new Vector2(0, _body2D.velocity.y);
        }

        _coroutine = StartCoroutine(KnockbackCoroutine(direction, duration, force));
    }

    private IEnumerator KnockbackCoroutine(Vector2 direction, float duration, float force)
    {
        _isKnockedBack = true;

        float timer = 0f;

        while (timer < duration)
        {
            _body2D.velocity = direction * force * (1 - (timer / duration));

            timer += Time.deltaTime;  
            yield return null;
        }

        // Убедимся, что скорость вернулась в нормальное состояние
        _body2D.velocity = new Vector2(0, _body2D.velocity.y);
        _isKnockedBack = false;
    }
}
