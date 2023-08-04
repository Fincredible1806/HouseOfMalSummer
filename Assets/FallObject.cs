using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObject : MonoBehaviour
{
    [SerializeField] AudioClip fallNoise;
    [SerializeField] string playerTag;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(playerTag))
            AudioSource.PlayClipAtPoint(fallNoise, transform.position);
    }
}
