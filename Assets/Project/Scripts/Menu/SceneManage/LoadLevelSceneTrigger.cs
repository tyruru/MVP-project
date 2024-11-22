using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class LoadLevelSceneTrigger : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private int _levelIndex;
    [SerializeField] private float _fadeDuration = 1f;

    private LoadScene _loadScene;
    private string _level = "Level";

    private void Awake()
    {
        _loadScene = new();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(FadeIn());
            Debug.Log("PlayerIn");
        }
    }

    public IEnumerator FadeIn()
    {
        Debug.Log("StartCoroutine");
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

        _image.color = new Color(startColor.r, startColor.g, startColor.b, 1f); // Убедимся, что в конце альфа равна 1
        _loadScene.LoadAndCloseScene(_level + _levelIndex, gameObject.scene.name);
    }
}
