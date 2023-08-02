using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceActTrigger : MonoBehaviour
{
    public PlayerInformation playerInfo;
    public AudioClip voiceClip;
    public AudioSource voiceSource;
    void Start()
    {
        voiceClip = playerInfo.startClip;
        voiceSource.clip = voiceClip;
        voiceSource.Play();


    }
    public void PlayNewClip()
    {
        voiceSource.clip = voiceClip;
        voiceSource.Play();
    }
}
