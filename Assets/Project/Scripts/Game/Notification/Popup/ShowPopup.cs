using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShowPopup : MonoBehaviour
{
    private PopupBoxContainer _popupBox;

    public void Show(TextData data)
    {
        if (_popupBox == null)
            _popupBox = FindObjectOfType<PopupBoxContainer>();

        if (_popupBox == null)
            return;

        _popupBox.ShowPopup(data);
    }

    public void Close()
    {
        if (_popupBox == null)
            return;

        _popupBox.ClosePopup();
    }
}
