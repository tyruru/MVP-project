using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class LoadLevelTransition : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] private float _fadeDuration = 1f;

    private void Awake()
    {
        Color startColor = _image.color;
        _image.color = new Color(startColor.r, startColor.g, startColor.b, 1f); // Убедимся, что в конце альфа равна 0
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut()
    {
        Color startColor = _image.color;
        float time = 0f;

        while (time < _fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startColor.a, 0f, time / _fadeDuration);
            _image.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        _image.color = new Color(startColor.r, startColor.g, startColor.b, 0f); // Убедимся, что в конце альфа равна 0
        _image.enabled = false;
    }
}
