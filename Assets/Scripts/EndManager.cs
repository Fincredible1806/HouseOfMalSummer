using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndManager : MonoBehaviour
{
    [SerializeField] private int worldNoteCount;
    [SerializeField] private GameObject player;
    [SerializeField] PlayerInformation playerInformation;
    [SerializeField] string goodEndSceneName;
    [SerializeField] string bestEndSceneName;
    [SerializeField] string badEndSceneName;

    private void OnTriggerEnter(Collider other)
    {
        int playerNoteCount = playerInformation.noteInfos.Count;
        if (playerNoteCount == worldNoteCount)
        {
            SceneManager.LoadScene(bestEndSceneName);
        }
        if (playerNoteCount >= worldNoteCount/2 && playerNoteCount < worldNoteCount)
        {
            SceneManager.LoadScene(goodEndSceneName);
        }
        else
        {
            SceneManager.LoadScene(badEndSceneName);
        }
    }
}
