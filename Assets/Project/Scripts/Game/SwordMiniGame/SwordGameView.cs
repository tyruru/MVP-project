using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SwordGameView : MonoBehaviour
{
    [SerializeField] private RectTransform _timingBar; // Шкала
    [SerializeField] private RectTransform _winZone;
    [SerializeField] private RectTransform _indicator;
    [SerializeField] private float _speed = 200f;
    [SerializeField] private KeyCode _keyCode = KeyCode.Space;

    private bool isMovingRight = true;
    private float _indicatorRect;

    public event Action<bool> OnIsPlayerWin;

    private void Update()
    {
        // Движение индикатора
        if (isMovingRight)
            _indicator.localPosition += Vector3.right * _speed * Time.deltaTime;
        else
            _indicator.localPosition += Vector3.left * _speed * Time.deltaTime;

        // Проверка на конец шкалы
        if (_indicator.localPosition.x >= _timingBar.rect.width / 2)
            isMovingRight = false;
        else if (_indicator.localPosition.x <= -_timingBar.rect.width / 2)
            isMovingRight = true;

        // Проверка попадания при нажатии
        if (Input.GetKeyDown(_keyCode)) 
        {
            float indicatorLeft = _indicator.localPosition.x - _indicator.rect.width / 2;
            float indicatorRight = _indicator.localPosition.x + _indicator.rect.width / 2;
            float greenZoneLeft = _winZone.localPosition.x - _winZone.rect.width / 2;
            float greenZoneRight = _winZone.localPosition.x + _winZone.rect.width / 2;

            if (indicatorRight >= greenZoneLeft && indicatorLeft <= greenZoneRight)
                OnIsPlayerWin?.Invoke(true);
            
            else
                OnIsPlayerWin?.Invoke(false);
        }
    }

    public void ChangeLevelView(Dictionary<Transform, float> level)
    {
        var key = level.Keys.First();
        var value = level.Values.First();

        // Перемещаем зону победы
        _winZone.transform.localPosition = key.localPosition;

        // Изменяем её размер (ширину)
        Vector2 newSize = _winZone.sizeDelta;
        newSize.x = value;

        _winZone.sizeDelta = newSize;
    }
}
