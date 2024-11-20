using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene 
{
    private AsyncOperation _operation;
    private string _sceneName;
    private string _sceneForClosing;

    public void Load(string sceneName)
    {
        StartLoad(sceneName);
    }

    public void LoadAndCloseScene(string sceneName, string sceneForClosing)
    {
        _sceneForClosing = sceneForClosing;
        StartLoad(sceneName);
    }

    private void StartLoad(string sceneName)
    {
        if (_operation != default)
        {
            return;
        }
        _sceneName = sceneName;
        _operation = SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);
        _operation.completed += ActivatedScene;
    }

    private void ActivatedScene(AsyncOperation op)
    {
        Scene scene = SceneManager.GetSceneByName(_sceneName);
        if (scene != default)
        {
            if (_sceneForClosing != null)
                SceneManager.UnloadScene(_sceneForClosing);

            if(scene.name != null)
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

}
