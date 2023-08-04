using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AtticOpener : MonoBehaviour
{
    [SerializeField] int neededNotes;
    [SerializeField] UnityEvent atticEvent;
    [SerializeField] PlayerInformation playerInfo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerInfo.noteInfos.Count >= neededNotes)
        {
            atticEvent.Invoke();
        }    
    }
}
