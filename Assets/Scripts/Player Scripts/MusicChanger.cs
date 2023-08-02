using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    public Collider musicChanger;
    [SerializeField] string playerTag;
    public AudioSource musicSource;
    [SerializeField] AudioClip newMusicClip;
    private void Awake()
    {
        musicChanger = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag) && musicSource.clip != newMusicClip)
        {
            musicSource.clip = newMusicClip;
            musicSource.Play();
        }
    }
}
