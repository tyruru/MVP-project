using UnityEngine.Assertions;
using UnityEngine;
using Zenject;

public sealed class PlayerPresenter : MonoPresenter
{
    [SerializeField] private PlayerView _playerView;

    [Inject] private readonly PlayerModel _playerModel;

    private void Awake()
    {
        Assert.IsNotNull(_playerView, "[player View] is null");
    }

    private void OnEnable()
    {
        
    }


    private void OnDisable()
    {
        
    }
}
