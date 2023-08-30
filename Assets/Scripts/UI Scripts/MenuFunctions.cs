using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuFunctions : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;
    public bool mainMenu;


    private void Start()
    {
        Time.timeScale = 1;
    }

    public void LoadGame()
    {
        StartCoroutine(EnterGame(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public IEnumerator EnterGame(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        if(mainMenu)
        SceneManager.LoadSceneAsync(levelIndex);
        Debug.Log("Loading level");
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game"); 
        Application.Quit();
    }
}
