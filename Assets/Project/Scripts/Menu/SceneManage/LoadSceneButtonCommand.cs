using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButtonCommand : ButtonCommand, IActivityScenesEditor
{
    private LoadScene _loadScene;

    [SerializeField] private bool _closePreviousScene = true;

    [SerializeField] private string _sceneName;
    public string SceneName
    {
        get => _sceneName;
        set => _sceneName = value;
    }

    private void Start()
    {
        _loadScene = new();
    }

    public override void Execute()
    {
        if (_closePreviousScene)
            _loadScene.LoadAndCloseScene(_sceneName, gameObject.scene.name);
        else
            _loadScene.Load(_sceneName);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        DOTween.KillAll();
    }
}
