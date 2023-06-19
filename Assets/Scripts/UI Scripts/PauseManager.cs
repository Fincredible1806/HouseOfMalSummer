using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject inGameUI;
    public GameObject noteButton;
    [SerializeField] PlayerInformation playerInformation;


    private void Awake()
    {
        noteButton.SetActive(false);
    }
    private void Start()
    {
        GameIsPaused = false;
    }
    public void ReturnToMenu()
    {
        //Returning to main menu
        SceneManager.LoadSceneAsync(0);
    }
    private void Update()
    {
        if (playerInformation.noteInfos.Count > 0)
            noteButton.SetActive(true);
        //Checking if the pause has been triggered by a Key on a computer (Test purposes only)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }    
    }
    public void Resume()
    {
        // pressing play
        pauseMenuUI.SetActive(false);
        inGameUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    public void Pause()
    {
        // Pausing the game
        inGameUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Quit()
    {
        // Quitting the game
        Debug.Log("Quit");
        Application.Quit();
    }

}
