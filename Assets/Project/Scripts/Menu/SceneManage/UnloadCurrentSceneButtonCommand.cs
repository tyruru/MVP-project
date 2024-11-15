using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class UnloadCurrentSceneButtonCommand : ButtonCommand
{
    public override void Execute()
    {
        SceneManager.UnloadScene(gameObject.scene.name);
    }
}
