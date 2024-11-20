using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButtonCommand : ButtonCommand
{
    private PlayerInputToggler _toggler;

    public override void  Execute()
    {
        if (_toggler == null)
            _toggler = FindObjectOfType<PlayerInputToggler>();

        Time.timeScale = 1f;

        if (_toggler != null)
            _toggler.EnableObjects();
    }
}
