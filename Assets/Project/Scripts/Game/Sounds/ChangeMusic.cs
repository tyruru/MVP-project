using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    private AudioSource audioSource; // Ссылка на AudioSource
    [SerializeField] private AudioClip newMusicClip;  // Новый аудиоклип

    private void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();

        if (audioSource != null && newMusicClip != null)
        {
            ChangeAudioClip(newMusicClip);
        }
        else
        {
            Debug.LogError("AudioSource или AudioClip не назначены!");
        }
    }

    public void ChangeAudioClip(AudioClip clip)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop(); // Останавливаем текущую музыку
        }

        audioSource.clip = clip; // Устанавливаем новый клип
        audioSource.Play();      // Запускаем воспроизведение
    }
}
