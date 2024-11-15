using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButtonCommand : ButtonCommand, IActivityScenesEditor
{
    private AsyncOperation _operation;

    [SerializeField] private bool _closePreviousScene = true;

    [SerializeField] private string _sceneName;
    public string SceneName
    {
        get => _sceneName;
        set => _sceneName = value;
    }

    public override void Execute()
    {
        if (_operation != default)
        {
            return;
        }
        _operation = SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);
        _operation.completed += ActivatedScene;
    }

    private void ActivatedScene(AsyncOperation op)
    {
        Scene scene = SceneManager.GetSceneByName(_sceneName);
        if (scene != default)
        {
            if (_closePreviousScene)
                SceneManager.UnloadScene(gameObject.scene.name);
            SceneManager.SetActiveScene(scene);
        }
        Complete();
    }

    private void Complete()
    {
        if (_operation != default)
        {
            _operation.completed -= ActivatedScene;
        }
        _operation = default;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        Complete();
        DOTween.KillAll();
    }
}
