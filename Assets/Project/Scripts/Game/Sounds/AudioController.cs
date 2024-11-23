using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NamesValome
{
    Music,
    Effects,
    MenuEffects
}

public class AudioController : MonoBehaviour
{
    public NamesValome nameOfVolume;
    public AudioSource audioSource;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("volume" + nameOfVolume))
            audioSource.volume = 1;
    }

    private void Update()
    {
        audioSource.volume = PlayerPrefs.GetFloat("volume" + nameOfVolume);
    }
}
