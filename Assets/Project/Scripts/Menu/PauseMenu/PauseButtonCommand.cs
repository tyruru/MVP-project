using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonCommand : ButtonCommand
{
    [SerializeField] private GameObject _pauseMenu;

    //private PlayerInputToggler _toggler;

    public override void Execute()
    {
        _pauseMenu.SetActive(true);

        //if (_toggler == null)
        //    _toggler = FindObjectOfType<PlayerInputToggler>();

        Time.timeScale = 0f;

        //if(_toggler != null)
        //    _toggler.DisableObjects();
    }

    public void HideButton()
    {
        _button.gameObject.SetActive(false); 
    }
}
