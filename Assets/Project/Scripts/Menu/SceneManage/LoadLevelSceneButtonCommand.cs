using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelSceneButtonCommand : ButtonCommand
{
    [SerializeField] private int _levelIndex;

    private LoadScene _loadScene;
    private string _level = "Level";

    private void Start()
    {
        _loadScene = new();
    }

    public override void Execute()
    {
        _loadScene.LoadAndCloseScene(_level + _levelIndex, gameObject.scene.name);
    }
}
