using Cinemachine;
using UnityEngine;

public class FollowTargetCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private string _targetTag = "Player";

    private GameObject _target;


    private void Update()
    {
        if (_target != null)
            return;

        if (_target == null)
            FindPlayer();

        if (_target != null)
            _virtualCamera.Follow = _target.transform;
    }

    private void FindPlayer()
    {
        _target = GameObject.FindGameObjectWithTag(_targetTag);
    }
}
