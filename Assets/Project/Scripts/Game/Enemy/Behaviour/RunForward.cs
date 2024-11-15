using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunForward : MonoBehaviour
{
    [SerializeField] private float _runTime;
    [SerializeField] private float _speedMultipier;
    [SerializeField] private MoveForward _moveForward;
    [SerializeField] private FindPlayer _findPlayer;

    private bool _isRunning;

    private void Start()
    {
        _isRunning = false;
    }

    private void Update()
    {
        if(_findPlayer.CurrentTarget != null && !_isRunning && _moveForward.CanWalk)
        {
            _moveForward.MultipliSpeed(_speedMultipier);
            _isRunning = true;
            StartCoroutine(RunCoroutine());
        }
    }

    private IEnumerator RunCoroutine()
    {
        yield return new WaitForSecondsRealtime(_runTime);
        _moveForward.NormilizeSpeed();
        _isRunning = false;
    }

}
