using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SetUpBindingView : MonoBehaviour
{
    public InputActionAsset inputActionAssets;
    public string mapName;

    private void Awake()
    {
        BindingController.SetUpAllBinds(inputActionAssets, mapName);
    }
}
