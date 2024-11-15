using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDialog : MonoBehaviour
{
    private DialogBoxContainer _dialogBox;

    public void Show(TextData data)
    {
        if (_dialogBox == null)
            _dialogBox = FindObjectOfType<DialogBoxContainer>();

        if (_dialogBox == null)
            return;

        _dialogBox.ShowDialog(data);
    }

    public void Close()
    {
        if (_dialogBox == null)
            return;

        _dialogBox.CloseDialog();
    }
}
