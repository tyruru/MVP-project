using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShowPopup
{
    private PopupBoxContainer _popupBox;

    public void Show(string text, PopupBoxContainer container)
    {
        if(_popupBox == null)
            _popupBox = container;

        _popupBox.ShowPopup(text);
    }

    public void Close()
    {
        if (_popupBox == null)
            return;

        _popupBox.ClosePopup();
    }
}
