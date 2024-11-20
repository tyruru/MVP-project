using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossTeleport : MonoBehaviour, IBossExecute
{
    private List<Vector3> _teleportPoints;
    private Transform _playerTransform;
    private Vector3 _currentTeleportPoint;


    private void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _teleportPoints = GameObject.FindGameObjectsWithTag("TeleportPoint")
                            .Select(x => x.GetComponent<Transform>().position)
                            .ToList();
    }

    public void Execute()
    {
        _currentTeleportPoint = FartherToPlayerPoint();
        Teleport(_currentTeleportPoint);
    }

    private Vector3 FartherToPlayerPoint()
    {
        Vector3 fartherPoint = new();
        float fartherDistance = 0;
        float distance;

        foreach(Vector3 point in _teleportPoints)
        {
            distance = Vector3.Distance(_playerTransform.position, point);
            if (distance > fartherDistance)
            {
                fartherDistance = distance;
                fartherPoint = point;
            }
        }

        return fartherPoint;
    }

    private void Teleport(Vector3 teleportPoint)
    {
        transform.position = teleportPoint;
    }
}
