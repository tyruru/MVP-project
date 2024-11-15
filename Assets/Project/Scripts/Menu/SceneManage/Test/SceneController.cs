//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Reflection;
//using DG.Tweening;
//using UnityEditor;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public abstract class SceneController : MonoBehaviour
//{ 
//    public string _sceneName;
//}

//[CustomEditor(typeof(SceneController), true)]
//public class SceneSelectorEditor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        base.OnInspectorGUI();
//        SceneController scene = (SceneController)target;

//        string[] scenes = GetSceneNamesFromActivities();

//        // Выпадающий список для выбора сцены
//        int selectedIndex = Mathf.Max(0, Array.IndexOf(scenes, scene._sceneName));
//        selectedIndex = EditorGUILayout.Popup("Select Scene", selectedIndex, scenes);

//        if (selectedIndex >= 0 && selectedIndex < scenes.Length)
//        {
//            scene._sceneName = scenes[selectedIndex];
//        }
//    }

//    private string[] GetSceneNamesFromActivities()
//    {
//        Type activitiesType = typeof(Scenes.Activities);
//        FieldInfo[] fields = activitiesType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
//        string[] sceneNames = new string[fields.Length];

//        for (int i = 0; i < fields.Length; i++)
//        {
//            sceneNames[i] = fields[i].GetValue(null).ToString();
//        }

//        return sceneNames;
//    }
//}
