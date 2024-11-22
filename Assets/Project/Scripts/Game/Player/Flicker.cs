using UnityEngine;
using DG.Tweening;


public class Flicker : MonoBehaviour
{
    [SerializeField] private float _duration;

    private HealthPresenter _healthPresenter;
    private Tween _flick;
    private SpriteRenderer _sprite;


    private void Awake()
    { 
        _healthPresenter = transform.parent.GetComponentInChildren<HealthPresenter>();
        _sprite = transform.parent.GetComponent<SpriteRenderer>();
        _flick = _sprite.DOFade(0, _duration).SetLoops(-1, LoopType.Yoyo);
    }

    private void Update()
    {
        if (!_healthPresenter.CanTakeDamage)
        {
            _flick.Play();
        }
        else
        {
            _flick.Pause();
            _sprite.color = new Color(_sprite.color.r, _sprite.color.g, _sprite.color.b, 1);
        }
    }
}
