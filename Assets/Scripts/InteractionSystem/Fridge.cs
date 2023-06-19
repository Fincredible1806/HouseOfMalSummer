using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
public class Fridge : AbstractInteractable
{

    public bool locked { get; set; }
    int timesUsed = 0;
    bool isOpened = false;
    [SerializeField] string lockedDoorText; 
    [SerializeField] string openDoorText;
    [SerializeField] string unlockDoorText;
    [SerializeField] string keyId;
    [SerializeField] string IceWaterId;
    private void Awake()
    {
        locked = true;
    }


    public override bool Interaction(Interaction interaction, PlayerInformation playerInformation)
    {
        if (playerInformation.playerInventory.ContainsKey(keyId))
        {
            locked = false;
        }
        if (!locked)
        {
            textOpacity.fadeTime = 3f;
            if (timesUsed < 1)
            {
                playerInformation.playerInventory.Add(IceWaterId, this);
                AudioSource.PlayClipAtPoint(interactSFX, transform.position);
                uiInfoText.text = unlockDoorText;
            }
            if (timesUsed > 0)
            {
                uiInfoText.text = openDoorText;
            }
            timesUsed++;
            Debug.Log("You opened the door!");
            isOpened = !isOpened;
            unityEvent?.Invoke(playerInformation);
        }
        else
        {
            textOpacity.fadeTime = 3f;
            uiInfoText.text = lockedDoorText;
        }
        return true;
    }

}
