using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SwordInteractable : MonoBehaviour, IInteractable, IActivityScenesEditor
{
    [SerializeField] private string _sceneName;

    private AbstractToggler<PlayerInput> _toggler;

    private void Start()
    {
        _toggler = FindObjectOfType<PlayerInputToggler>();
    }

    public string SceneName
    {
        get => _sceneName;
        set => _sceneName = value;
    }

    public void Execute()
    {
        if (IsSceneLoaded())
            return;

        SceneManager.LoadScene(_sceneName, LoadSceneMode.Additive);
    }

    private bool IsSceneLoaded()
    {
        return SceneManager.GetSceneByName(_sceneName).isLoaded;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += GameLoad;
        SceneManager.sceneUnloaded += GameUnload;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= GameLoad;
        SceneManager.sceneUnloaded -= GameUnload;
    }

    private void GameLoad(Scene scene, LoadSceneMode mode)
    {
        if(scene.name.Equals(_sceneName))
            _toggler.DisableObjects();
    }

    private void GameUnload(Scene scene)
    {
        if (scene.name.Equals(_sceneName))
            _toggler.EnableObjects();
    }
}

