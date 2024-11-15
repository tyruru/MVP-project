using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

#if UNITY_EDITOR // => Ignore from here to next endif if not in editor
using UnityEditor;
#endif

public interface IActivityScenesEditor
{
    string SceneName { get; set; }
}

#if UNITY_EDITOR
[CustomEditor(typeof(MonoBehaviour), true)]
public class ActivityScenesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        // Проверяем, что объект реализует интерфейс IActivityScenesEditor
        if (target is IActivityScenesEditor sceneController)
        {
            string[] scenes = GetSceneNamesFromActivities();

            // Выпадающий список для выбора сцены
            int selectedIndex = Mathf.Max(0, Array.IndexOf(scenes, sceneController.SceneName));
            selectedIndex = EditorGUILayout.Popup("Select Scene", selectedIndex, scenes);

            if (selectedIndex >= 0 && selectedIndex < scenes.Length)
            {
                // Присваиваем выбранное значение свойству SceneName
                sceneController.SceneName = scenes[selectedIndex];

                // Отмечаем объект как измененный для сохранения изменений
                EditorUtility.SetDirty(target);

                // Сохраняем модификации в SerializedObject
                serializedObject.Update();
                serializedObject.ApplyModifiedProperties();
            }
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
#endif
