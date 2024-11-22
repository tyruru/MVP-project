using System;
using Unity.VisualScripting;
using UnityEngine;

public class ShowDialogInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] TextData _bound;

    private ShowDialog _showDialog;

    public event Action OnDialogEnd;

    private void Start()
    {
        _showDialog = new();
        _showDialog.OnDialogEnd += DialogEnd;
    }

    public void Execute()
    {
        _showDialog.Show(_bound, FindObjectOfType<DialogBoxContainer>());
    }

    private void DialogEnd()
    {
        OnDialogEnd?.Invoke();
    }

    private void OnDestroy()
    {
        _showDialog.OnDialogEnd -= DialogEnd;
    }
}
