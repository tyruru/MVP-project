using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public float oldVolume;
    public NamesValome nameOfVolume;

    private void Start()
    {
        oldVolume = slider.value;
        if (!PlayerPrefs.HasKey("volume" + nameOfVolume))
            slider.value = 1;
        else
            slider.value = PlayerPrefs.GetFloat("volume" + nameOfVolume);
    }

    private void Update()
    {
        if (oldVolume != slider.value)
        {
            PlayerPrefs.SetFloat("volume" + nameOfVolume, slider.value);
            PlayerPrefs.Save();
            oldVolume = slider.value;
        }
    }

}
