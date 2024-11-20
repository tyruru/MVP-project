using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMenu : MonoCommand
{
    [SerializeField] private GameObject _deadMenu;

    public override void Execute()
    {
        _deadMenu.SetActive(true);
    }
}
