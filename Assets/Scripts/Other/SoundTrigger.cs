using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
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
                    AS.Play();
                }
            }
        }
}
