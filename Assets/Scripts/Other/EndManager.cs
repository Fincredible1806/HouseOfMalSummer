using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class EndManager : MonoBehaviour
{
    [SerializeField] private int worldNoteCount;
    [SerializeField] private GameObject player;
    [SerializeField] PlayerInformation playerInformation;
    [SerializeField] string goodEndSceneName;
    [SerializeField] string bestEndSceneName;
    [SerializeField] string badEndSceneName;
    [SerializeField] UnityEvent endCollideEvent;
    [SerializeField] string memCardId;

    public void Ending()
    {
        endCollideEvent.Invoke();
        int playerNoteCount = playerInformation.noteInfos.Count;
        if (playerInformation.playerInventory.ContainsKey(memCardId) && playerNoteCount >= worldNoteCount/2)
        {
            SceneManager.LoadScene(bestEndSceneName);
            return;
        }
        if(playerNoteCount >= worldNoteCount/2)
        {
            SceneManager.LoadScene(goodEndSceneName);
            return;
        }
        else
        {
            SceneManager.LoadScene(badEndSceneName);
        }
    }
}
