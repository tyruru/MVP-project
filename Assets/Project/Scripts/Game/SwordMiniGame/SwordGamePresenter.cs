using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordGamePresenter : MonoBehaviour
{
    [SerializeField] private SwordGameView _view;
    [SerializeField] SwordGameModel _model;

    private void Start()
    {
        NextLevel();
    }

    private void OnEnable()
    {
        _view.OnIsPlayerWin += GameResult;
    }

    private void OnDisable()
    {
        _view.OnIsPlayerWin -= GameResult;
    }

    private void GameResult(bool isWin)
    {
        if (isWin)
            NextLevel();
        else
            Lose();
    }

    private void NextLevel()
    {
        var nextLevel = _model.NextLevel();

        if (nextLevel != null)
            _view.ChangeLevelView(nextLevel);
        else
            Win();
    }

    private void Lose()
    {
        Debug.Log("Miss");
    }

    private void Win()
    {
        Debug.Log("Win");
    }
}

