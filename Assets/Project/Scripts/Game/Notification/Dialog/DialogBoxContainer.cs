using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogBoxContainer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _container;
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
    private AbstractToggler<PlayerInput> _playerToggler;
    private Button _pauseButton;

    public event Action OnDialogEnd;

    private void Start()
    {
        _container.SetActive(false);
    }

    public void ShowDialog(TextData data)
    {
        if(_playerToggler == null)
            _playerToggler = FindObjectOfType<PlayerInputToggler>();

        if (_container.active == true)
            return;

        _data = data;
        _currentSentence = 0;
        _text.text = string.Empty;

        _container.SetActive(true);
        _playerToggler.DisableObjects();
        OnStartDialogAnimation(); // Перенести вызов в аниматор
    }

    public void CloseDialog()
    {
        _playerToggler.EnableObjects();
        _container.SetActive(false);
    }

    private IEnumerator StartDialogText()
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

    private void OnStartDialogAnimation()
    {
        _typingRoutine = StartCoroutine(StartDialogText());
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

        if(isDialogCompleted)
        {
            OnDialogEnd?.Invoke();
            HideDialogBox();
        }
        else
        {
            OnStartDialogAnimation();
        }
    }

    private void HideDialogBox()
    {
        // анимация закрытие
        // звук закрития
        CloseDialog();
    }

    private void StopTypeAnimation()
    {
        if (_typingRoutine != null)
            StopCoroutine(_typingRoutine);

        _typingRoutine = null;
    }

    [SerializeField] private TextData _testData;
    public void Test()
    {
        ShowDialog(_testData);
    }

    
}

