using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SwordGamePresenter : MonoBehaviour
{
    [SerializeField] private SwordGameView _view;
    [SerializeField] SwordGameModel _model;

    public static event Action OnGameEnd;

    private bool _winGame = false;

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
        if (!_winGame)
        {
            if (isWin)
                NextLevel();
            else
                Lose();
        }
        else
        {
            SceneManager.UnloadScene(gameObject.scene.name);
            OnGameEnd?.Invoke();
        }
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
        var level = _model.Restart();

        _view.ChangeLevelView(level);
    }

    private void Win()
    {
        _winGame = true;
    }
}

