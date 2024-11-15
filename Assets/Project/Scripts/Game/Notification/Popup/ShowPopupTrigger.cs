using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPopupTrigger : MonoBehaviour
{
    [SerializeField] TextData _bound;

    private ShowPopup _showPopup;
    private bool _triggerEnter;

    private void Start()
    {
        _showPopup = new();
    }

    private void Show()
    {
        _showPopup.Show(_bound);
    }

    private void Close()
    {
        _showPopup.Close();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
            _triggerEnter = true;
    }

    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == "Player")
            _triggerEnter = false;
    }

    private void Update()
    {
        if (_triggerEnter)
            Show();
        else
            Close();
    }
}