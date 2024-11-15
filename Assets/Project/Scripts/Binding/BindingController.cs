using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class BindingController
{
    private const string RebindsKey = "rebinds";

    public static void SetUpAllBinds(InputActionAsset inputActionAssets, string mapName)
    {
        InputActionMap actionMap = inputActionAssets.FindActionMap(mapName);  

        if (actionMap == null)
        {
            Debug.LogError($"ActionMap {actionMap.name} не найдено!");
            return;
        }

        foreach (InputAction action in actionMap.actions)
        {
            string key = RebindsKey + action.name;

            // Если есть сохранённые бинды для этого действия, загружаем их
            if (PlayerPrefs.HasKey(key))
            {
                string rebindsJson = PlayerPrefs.GetString(key);
                action.LoadBindingOverridesFromJson(rebindsJson);  // Применяем бинды
            }
        }
    }

    public static void SaveBind(InputActionReference inputAction)
    {
        var action = inputAction.action;
        string rebindsJson = action.SaveBindingOverridesAsJson();  
        PlayerPrefs.SetString(RebindsKey + action.name, rebindsJson);  

        PlayerPrefs.Save();
    }
}
