using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    private static float gameVolume = 1f;
    private void Start()
    {
        gameVolume = PlayerPrefs.GetFloat("volume");
        audioMixer.SetFloat("volume", gameVolume);
        volumeSlider.value = gameVolume;
    }
    private void Update()
    {
        audioMixer.SetFloat("volume", gameVolume);
        PlayerPrefs.SetFloat("volume", gameVolume);



    }
    public void VolumeUpdater(float volume)
    {
        gameVolume = volume;
    }




}


