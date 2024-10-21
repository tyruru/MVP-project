using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[CustomEditor(typeof(RebindManager))]

public class RebindManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        RebindManager rebindManager = (RebindManager)target;

        // Проверка, инициализирована ли привязка
        if (rebindManager.currentBinding.actionReference != null)
        {
            var action = rebindManager.currentBinding.actionReference.action;

            if (action != null)
            {
                var bindings = action.bindings;

                // Создаем массив строк для отображения в выпадающем списке
                string[] bindingNames = new string[bindings.Count];
                for (int i = 0; i < bindings.Count; i++)
                {
                    bindingNames[i] = $"{i}: {InputControlPath.ToHumanReadableString(bindings[i].effectivePath)}";
                }

                // Выпадающий список для выбора индекса
                int selectedIndex = EditorGUILayout.Popup("Select Binding", rebindManager.currentBinding.bindingIndex, bindingNames);

                // Обновляем выбранный индекс
                if (selectedIndex != rebindManager.currentBinding.bindingIndex)
                {
                    rebindManager.currentBinding.bindingIndex = selectedIndex;
                    EditorUtility.SetDirty(rebindManager);
                }
            }
            else
            {
                EditorGUILayout.LabelField("No Input Action assigned.");
            }
        }
        else
        {
            EditorGUILayout.LabelField("No Input Action Reference assigned.");
        }
    }
}
