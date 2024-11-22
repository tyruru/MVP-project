using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPopupTrigger : MonoBehaviour
{
    [SerializeField] private string _text = "Press interact button";

    private ShowPopup _showPopup;
    private bool _triggerEnter;

    private void Start()
    {
        _showPopup = new();
    }

    private void Show()
    {
        _showPopup.Show(_text);
    }

    private void Close()
    {
        _showPopup.Close();
    }

    //private void OnTriggerEnter2D(Collider2D target)
    //{
    //    if (target.tag == "Player")
    //        _triggerEnter = true;
    //}

    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            Close();
        }
    }

    private void OnTriggerStay2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            Show();
        }
    }


    //private void Update()
    //{
    //    if (_triggerEnter)

    //    else
    //        Close();
    //}

 
}
