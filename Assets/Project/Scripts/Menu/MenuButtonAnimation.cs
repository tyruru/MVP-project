using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using DG.Tweening;

public class MenuButtonAnimation : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Color _hoverColor, _baseColor, _clickColor;

    private Button _button;

    private Tween _hoverTween, _exitTween, _clickDownTween, _clickUpTween;

    private List<Tween> _tweens;

    private void Awake()
    {
        _button = GetComponent<Button>();
        Assert.IsNotNull(_button, "[Button] is missed");
    }

    private void Start()
    {
        _tweens = new List<Tween>()
        {
            (_hoverTween = _button.GetComponent<Image>().DOColor(_hoverColor, 1).Pause().SetAutoKill(false)),
            (_exitTween = _button.GetComponent<Image>().DOColor(_baseColor, 1).Pause().SetAutoKill(false)),
            (_clickDownTween = _button.GetComponent<Image>().DOColor(_clickColor, 1).Pause().SetAutoKill(false)),
            (_clickUpTween = _button.GetComponent<Image>().DOColor(_hoverColor, 1).Pause().SetAutoKill(false)),
        };
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TweenController(_hoverTween);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TweenController(_exitTween);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TweenController(_clickDownTween);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        TweenController(_clickUpTween);
    }

    private void TweenController(Tween tween)
    {
        foreach (Tween elTween in _tweens)
        {
            if (tween.Equals(elTween))
            {
                elTween.Restart();
                //Debug.Log("Restart: " + elTween.debugTargetId);
            }
            else
            {
                elTween.Pause();
                //Debug.Log("Pause: " + elTween.debugTargetId);
            }
        }
       
    }

    private void OnDisable()
    {
        foreach (Tween tween in _tweens)
            tween.Pause();

        Color color = Color.white;
        color.a = 0;
        _button.GetComponent<Image>().color = color;
    }
}
