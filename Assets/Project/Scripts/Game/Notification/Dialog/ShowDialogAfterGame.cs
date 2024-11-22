using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShowDialogAfterGame : MonoBehaviour
{
    [SerializeField] private TextData _bound;
    [SerializeField] private GameObject _winZone;
    [SerializeField] ShowPopupTrigger _popup;

    private ShowDialog _showDialog;

    private void Awake()
    {
        SwordGamePresenter.OnGameEnd += StartDialog;
        _winZone.SetActive(false);
    }

    private void StartDialog()
    {
        _showDialog = new();
        _showDialog.OnDialogEnd += ShowEndZone;
        _showDialog.Show(_bound, FindObjectOfType<DialogBoxContainer>());
        _popup.enabled = false;
    }

    private void ShowEndZone()
    {
        if(_winZone != null)
            _winZone.SetActive(true);
    }
}
