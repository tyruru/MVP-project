using System;
using UnityEngine;

public class ShowDialog
{
    private DialogBoxContainer _dialogBox;

    public event Action OnDialogEnd;

    public void Show(TextData data, DialogBoxContainer container)
    {
        if(_dialogBox == null)
            _dialogBox = container;

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
