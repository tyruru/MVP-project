using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelSceneTrigger : MonoBehaviour
{
    [SerializeField] private int _levelIndex;

    private LoadScene _loadScene;
    private string _level = "Level";

    private void Start()
    {
        _loadScene = new();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            _loadScene.LoadAndCloseScene(_level + _levelIndex, gameObject.scene.name);
    }
}
