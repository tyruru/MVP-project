using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PopupBoxContainer : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _container;
    [SerializeField] GameObject _dialogContainer;

    //[SerializeField] private Animator _animator;

    [Space]
    [SerializeField] private float _textSpeed = 0.09f;

    [Header("Sounds")]
    //[SerializeField] private AudioClip _typing;
    //[SerializeField] private AudioClip _open;
    //[SerializeField] private AudioClip _close;

    private string _message;
    private AudioSource _sfxSource;

    private Coroutine _typingRoutine;

    public void ShowPopup(string text)
    {
        if (_dialogContainer.active)
        {
            ClosePopup();
            return;
        }

        if (_container.active)
            return;

        _message = text;
        _text.text = string.Empty;

        _container.SetActive(true);
        OnStartPopupAnimation(); // Перенести вызов в аниматор
    }

    public void ClosePopup()
    {
        _container.SetActive(false);
    }

    private IEnumerator StartPopupText()
    {
        _text.text = string.Empty;
        var sentence = _message;

        foreach (var letter in sentence)
        {
            _text.text += letter;
            // typing Sound play OneShot()
            yield return new WaitForSeconds(_textSpeed);
        }

        _typingRoutine = null;
    }

    private void OnStartPopupAnimation()
    {
        _typingRoutine = StartCoroutine(StartPopupText());
    }


    private void OnCloseAnimationComplete()
    {

    }

    private void HideDialogBox()
    {
        // анимация закрытие
        // звук закрития
        ClosePopup();
    }

    private void StopTypeAnimation()
    {
        if (_typingRoutine != null)
            StopCoroutine(_typingRoutine);

        _typingRoutine = null;
    }
}
