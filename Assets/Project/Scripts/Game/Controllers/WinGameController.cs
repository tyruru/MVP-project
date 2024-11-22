using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WinGameController : MonoBehaviour
{
    [SerializeField] private ShowDialogInteractable _dialog;
    [SerializeField] private Image _image;
    [SerializeField] private float _fadeDuration;

    private void Awake()
    {
        _dialog.OnDialogEnd += DialogEnd;
    }

    private void DialogEnd()
    {
        StartCoroutine(FadeIn());

    }

    public IEnumerator FadeIn()
    {
        LoadScene loadScene = new();

        _image.enabled = true;
        Color startColor = _image.color;
        float time = 0f;

        while (time < _fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startColor.a, 1f, time / _fadeDuration);
            _image.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        _image.color = new Color(startColor.r, startColor.g, startColor.b, 1f); 

        loadScene.LoadAndCloseScene("EndScene", gameObject.scene.name);
    }
}
