using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NoteDisplayerManager : MonoBehaviour
{
    [SerializeField] Button leftButton;
    [SerializeField] Button rightButton;
    [SerializeField] TextMeshProUGUI theText;
    [SerializeField] int displayedTextNo;
    [SerializeField] PlayerInformation playerInformation;
    private void Awake()
    {
        leftButton.onClick.RemoveAllListeners();
        rightButton.onClick.RemoveAllListeners();
        leftButton.onClick.AddListener(PreviousIndex);
        rightButton.onClick.AddListener(NextIndex);
    }

    private void OnEnable()
    {
        displayedTextNo = playerInformation.noteInfos.Count - 1;
        displayInfoText();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void PreviousIndex()
    {
        displayedTextNo--;
        if (displayedTextNo < 0)
        {
            displayedTextNo = playerInformation.noteInfos.Count - 1;
        }
        displayInfoText();
    }

    void NextIndex()
    {
        displayedTextNo++;
        if(displayedTextNo >= playerInformation.noteInfos.Count)
        {
            displayedTextNo = 0;
        }
        displayInfoText();
    }

    void displayInfoText()
    {
        theText.text = playerInformation.noteInfos[displayedTextNo];
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

