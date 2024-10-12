using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class BootstrapController : MonoBehaviour
{
    private AsyncOperation _loadLobbyOperation;

    private void Awake()
    {
        SceneManager.LoadSceneAsync(Scenes.System.MainCamera, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync(Scenes.System.Audio, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync(Scenes.System.Input, LoadSceneMode.Additive);

        _loadLobbyOperation = SceneManager.LoadSceneAsync(Scenes.Activities.MainMenu, LoadSceneMode.Additive);
        _loadLobbyOperation.completed += OnLobbySceneLoaded;
    }

    private void OnLobbySceneLoaded(AsyncOperation operation)
    {
        SceneManager.UnloadSceneAsync(gameObject.scene.name);
    }

    private void OnDestroy()
    {
        _loadLobbyOperation.completed -= OnLobbySceneLoaded;
    }
}
