//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Reflection;
//using DG.Tweening;
//using UnityEditor;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public interface SceneControllerTest
//{
//    public string SceneName { get; set; }
//}

//[CustomEditor(typeof(MonoBehaviour), true)]
//public class SceneSelectorEditorTest : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        base.OnInspectorGUI();

//        if (target is SceneControllerTest sceneController)
//        {
//            string[] scenes = GetSceneNamesFromActivities();

//            // Выпадающий список для выбора сцены
//            int selectedIndex = Mathf.Max(0, Array.IndexOf(scenes, sceneController.SceneName));
//            selectedIndex = EditorGUILayout.Popup("Select Scene", selectedIndex, scenes);

//            if (selectedIndex >= 0 && selectedIndex < scenes.Length)
//            {
//                sceneController.SceneName = scenes[selectedIndex];
//                EditorUtility.SetDirty(target); // Помечаем объект как изменённый, чтобы изменения сохранялись
//            }
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
