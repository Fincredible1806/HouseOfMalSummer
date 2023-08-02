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

    private void OnTriggerEnter(Collider other)
    {
        endCollideEvent.Invoke();

        int playerNoteCount = playerInformation.noteInfos.Count;
        if (playerNoteCount == worldNoteCount)
        {
            SceneManager.LoadSceneAsync(bestEndSceneName);
        }
        if (playerNoteCount >= worldNoteCount/2 && playerNoteCount < worldNoteCount)
        {
            SceneManager.LoadSceneAsync(goodEndSceneName);
        }
        else
        {
            SceneManager.LoadSceneAsync(badEndSceneName);
        }
    }
}
