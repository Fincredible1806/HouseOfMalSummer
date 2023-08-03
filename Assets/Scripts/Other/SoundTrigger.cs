using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    [SerializeField] AudioClip[] soundClips;
    [Range(0.1f, 1)]
    [SerializeField] float triggerChance;
    [SerializeField] float minValue;
    [SerializeField] float maxValue;
    private float triggerSet;
    [SerializeField] string playerTag;
    [SerializeField] AudioSource AS;
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(playerTag))
            {
                triggerSet = Random.Range(minValue, maxValue);
                if (triggerChance <= triggerSet)
                {
                SoundPicker();
                }
            }
        }

    void SoundPicker()
    {
        AudioClip clip = soundClips[Random.Range(0, soundClips.Length)];
        AS.clip = clip;
        AS.Play();
    }
}
