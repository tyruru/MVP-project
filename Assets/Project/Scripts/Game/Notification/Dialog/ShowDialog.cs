using System;
using UnityEngine;

public class ShowDialog : MonoBehaviour
{
    private DialogBoxContainer _dialogBox;

    public event Action OnDialogEnd;

    public void Show(TextData data)
    {
        if (_dialogBox == null)
            _dialogBox = FindObjectOfType<DialogBoxContainer>();

        if (_dialogBox == null)
            return;

        _dialogBox.ShowDialog(data);
        _dialogBox.OnDialogEnd += EndDialog;
    }

    public void Close()
    {
        if (_dialogBox == null)
            return;

        _dialogBox.CloseDialog();
    }

    private void EndDialog()
    {
        OnDialogEnd?.Invoke();
    }
}
