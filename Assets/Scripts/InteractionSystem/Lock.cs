using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public void Unlocked()
    {
        rb.useGravity = true;
        Destroy(gameObject, 5f);
    }    
}
