using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossAttackId
{
    Teleport = 10,
    FireballAttack = 11,
}

public class BossAI : MonoBehaviour
{
    [SerializeField] private float _waitTime;

    private BossTeleport _teleport;
    private BossFireballAttack _fireballAttack;

    private bool _canAttack;
    private bool _isNeedRandomAttack;
    private BossAttackId _attackId;
    private BossAttackId _idTemplete;
    public int GetAttackId => (int)_attackId;

    public bool IsAttack { get; private set; }

    private void Awake()
    {
        _teleport = GetComponent<BossTeleport>();
        _fireballAttack = GetComponent<BossFireballAttack>();

        _canAttack = true;
        IsAttack = false;
        _isNeedRandomAttack = true;
    }

    private void Update()
    {
        if (_canAttack && !IsAttack)
        {
            if (_isNeedRandomAttack)
                _attackId = GetRandomAttack();
            else
                _attackId = _idTemplete;
            _isNeedRandomAttack = true;

            StartAttack();
        }
    }

    public static BossAttackId GetRandomAttack()
    {
        Array values = Enum.GetValues(typeof(BossAttackId));

        int randomIndex = UnityEngine.Random.Range(0, values.Length);

        return (BossAttackId)values.GetValue(randomIndex);
    }

    private void TeleportAttack()
    {
        _teleport.Execute();
        _isNeedRandomAttack = false;
        _idTemplete = BossAttackId.FireballAttack;


        StartCoroutine(WaitBeforeAttack(_waitTime));
    }

    private void FireballAttack()
    {
        StartCoroutine(FireballAttackCoroutine(1, _fireballAttack));
        _isNeedRandomAttack = false;
        _idTemplete = BossAttackId.Teleport;
    }

    private IEnumerator WaitBeforeAttack(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        _canAttack = true;
    }

    private IEnumerator FireballAttackCoroutine(float time, IBossExecute execute)
    {
        for(int i = 0; i < 3; i++)
        {
            yield return new WaitForSecondsRealtime(time);
            execute.Execute();
        }

        StartCoroutine(WaitBeforeAttack(_waitTime));
    }


    public void StartAttack()
    {
        _canAttack = false;
        IsAttack = true;
    }

    public void EndAttack()
    {
        IsAttack = false;
    }
}