using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadCurrentSceneButtonCommand : ButtonCommand
{
    private LoadScene _loadScene;

    public override void Execute()
    {
        _loadScene = new();
        string sceneName = gameObject.scene.name;
        _loadScene.LoadAndCloseScene(sceneName, sceneName);
    }
}
