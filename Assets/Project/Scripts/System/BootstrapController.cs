using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class BootstrapController : MonoBehaviour
{
    private AsyncOperation _loadLobbyOperation;
    private bool _isLobbyLoaded;

    private void Awake()
    {
        SceneManager.LoadSceneAsync(Scenes.System.MainCamera, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync(Scenes.System.Audio, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync(Scenes.System.Input, LoadSceneMode.Additive);

        _loadLobbyOperation = SceneManager.LoadSceneAsync(Scenes.Activities.LoadMenu, LoadSceneMode.Additive);
        _loadLobbyOperation.completed += OnLobbySceneLoaded;
    }

    private void OnLobbySceneLoaded(AsyncOperation operation)
    {
        _isLobbyLoaded = operation.isDone;
    }

    private void Update()
    {
        if (_isLobbyLoaded)
        {
            SceneManager.UnloadSceneAsync(gameObject.scene.name);
        }
    }

    private void OnDestroy()
    {
        _loadLobbyOperation.completed -= OnLobbySceneLoaded;
    }
}
