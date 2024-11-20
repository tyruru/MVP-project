using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShowPopup : MonoBehaviour
{
    private PopupBoxContainer _popupBox;

    public void Show(string text)
    {
        if (_popupBox == null)
            _popupBox = FindObjectOfType<PopupBoxContainer>();

        if (_popupBox == null)
            return;

        _popupBox.ShowPopup(text);
    }

    public void Close()
    {
        if (_popupBox == null)
            return;

        _popupBox.ClosePopup();
    }
}
