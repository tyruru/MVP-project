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

    private TextData _data;
    private int _currentSentence;
    private AudioSource _sfxSource;

    private Coroutine _typingRoutine;

    public void ShowPopup(TextData data)
    {
        if (_dialogContainer.active)
        {
            ClosePopup();
            return;
        }

        if (_container.active)
            return;

        _data = data;
        _currentSentence = 0;
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
        var sentence = _data.Sentences[_currentSentence];

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

    public void OnSkip()
    {
        if (_typingRoutine == null)
            return;

        StopTypeAnimation();
        _text.text = _data.Sentences[_currentSentence];
    }

    public void OnContinue()
    {
        StopTypeAnimation();
        _currentSentence++;

        var isDialogCompleted = _currentSentence >= _data.Sentences.Length;

        if (isDialogCompleted)
        {
            HideDialogBox();
        }
        else
        {
            OnStartPopupAnimation();
        }
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
