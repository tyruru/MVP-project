using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class TakeDamageEffect : MonoBehaviour
{
    [SerializeField] private PostProcessVolume postProcessVolume;
    private Vignette vignette;

    [SerializeField] private float effectDuration = 0.5f; // Длительность эффекта
    [SerializeField] private float maxIntensity = 0.5f; // Максимальная интенсивность
    [SerializeField] private Color damageColor = Color.red; // Цвет при уроне

    private float timer;

    private void Start()
    {
        // Получаем Vignette из профиля Post-Processing
        if (postProcessVolume.profile.TryGetSettings(out vignette))
        {
            vignette.intensity.value = 0f; // Начальное значение
        }
    }

    private void Update()
    {
        // Если эффект активен, уменьшаем интенсивность
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            vignette.intensity.value = Mathf.Lerp(0f, maxIntensity, timer / effectDuration);
        }
    }

    public void TriggerDamageEffect()
    {
        if (vignette != null)
        {
            vignette.intensity.value = maxIntensity; // Устанавливаем максимальную интенсивность
            vignette.color.value = damageColor; // Цвет эффекта
            timer = effectDuration; // Запускаем таймер
        }
    }
}
