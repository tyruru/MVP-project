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

    public static event Action OnFightStart;
    public static event Action OnFightEnd;


    private BossTeleport _teleport;
    private BossFireballAttack _fireballAttack;
    private Death _death;

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
        _death = GetComponent<Death>();
        OnFightStart?.Invoke();
    }

    private void Update()
    {
        if (_death.IsDead)
            return;

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

    }

    private void FireballAttack()
    {
        //StartCoroutine(FireballAttackCoroutine(1, _fireballAttack));
        _fireballAttack.Execute();
        _isNeedRandomAttack = false;
        _idTemplete = BossAttackId.Teleport;
    }

    private IEnumerator WaitBeforeAttack(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        _canAttack = true;
    }

    public void StartAttack()
    {
        _canAttack = false;
        IsAttack = true;
    }

    public void EndAttack()
    {
        IsAttack = false;
        StartCoroutine(WaitBeforeAttack(_waitTime));
    }

    private void FightEnd()
    {
        OnFightEnd.Invoke();

    }
}
