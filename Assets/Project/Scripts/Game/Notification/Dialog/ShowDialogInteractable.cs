using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowDialogInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] TextData _bound;

    private ShowDialog _showDialog;

    private void Start()
    {
        _showDialog = new();
    }

    public void Execute()
    {
        _showDialog.Show(_bound);
    }
}
