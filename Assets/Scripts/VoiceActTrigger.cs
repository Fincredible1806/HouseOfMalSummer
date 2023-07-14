using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceActTrigger : MonoBehaviour
{
    public PlayerInformation playerInfo;
    public AudioClip voiceClip;
    void Start()
    {
        voiceClip = playerInfo.startClip;
        AudioSource.PlayClipAtPoint(voiceClip, transform.position);


    }
    public void PlayNewClip()
    {
        AudioSource.PlayClipAtPoint(voiceClip, transform.position);
    }
}
