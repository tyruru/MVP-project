using UnityEngine;
using UnityEngine.InputSystem;

#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(RebindCommand))]

public class RebindCommandEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        RebindCommand rebindCommand = (RebindCommand)target;

        // Проверка, инициализирована ли привязка
        if (rebindCommand.currentBinding.actionReference != null)
        {
            var action = rebindCommand.currentBinding.actionReference.action;

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
                int selectedIndex = EditorGUILayout.Popup("Select Binding", rebindCommand.currentBinding.bindingIndex, bindingNames);

                // Обновляем выбранный индекс
                if (selectedIndex != rebindCommand.currentBinding.bindingIndex)
                {
                    rebindCommand.currentBinding.bindingIndex = selectedIndex;
                    EditorUtility.SetDirty(rebindCommand);
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
#endif