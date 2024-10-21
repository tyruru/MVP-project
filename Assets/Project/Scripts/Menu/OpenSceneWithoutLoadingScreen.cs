using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.Reflection;
using System;
using UnityEditor.U2D.Path;
using DG.Tweening;

public class OpenSceneWithoutLoadingScreen : ButtonCommand
{
    private AsyncOperation _operation;

    [HideInInspector] public string _sceneName;

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

[CustomEditor(typeof(OpenSceneWithoutLoadingScreen))]
public class SceneSelectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        OpenSceneWithoutLoadingScreen scene = (OpenSceneWithoutLoadingScreen)target;

        string[] scenes = GetSceneNamesFromActivities();

        // Выпадающий список для выбора сцены
        int selectedIndex = Mathf.Max(0, Array.IndexOf(scenes, scene._sceneName));
        selectedIndex = EditorGUILayout.Popup("Select Scene", selectedIndex, scenes);

        if (selectedIndex >= 0 && selectedIndex < scenes.Length)
        {
            scene._sceneName = scenes[selectedIndex];
        }
    }

    private string[] GetSceneNamesFromActivities()
    {
        Type activitiesType = typeof(Scenes.Activities);
        FieldInfo[] fields = activitiesType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
        string[] sceneNames = new string[fields.Length];

        for (int i = 0; i < fields.Length; i++)
        {
            sceneNames[i] = fields[i].GetValue(null).ToString();
        }

        return sceneNames;
    }
}
