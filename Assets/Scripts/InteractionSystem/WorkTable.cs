using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class WorkTable : AbstractInteractable
{
    [SerializeField] string[] neededIds;
    [SerializeField] PlayerInformation playerInformation;
    [SerializeField] int correctIds;
    [SerializeField] string notEnoughTexts;
    public override bool Interaction(Interaction interaction, PlayerInformation playerInformation)
    {
        foreach(string id in neededIds)
        {
            if(playerInformation.playerInventory.ContainsKey(id))
            {
                correctIds++;
            }
        }
        if (correctIds == neededIds.Length)
        {
            textOpacity.fadeTime = 3f;
            uiInfoText.text = infoText;
            unityEvent?.Invoke(playerInformation);
            gameObject.layer = 0;
            return true;
        }
        textOpacity.fadeTime = 3f;
        uiInfoText.text = notEnoughTexts;
        return false;
    }
}