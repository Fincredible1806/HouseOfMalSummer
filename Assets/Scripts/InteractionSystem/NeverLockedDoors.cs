using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeverLockedDoors : AbstractInteractable
{
    bool isOpened = false;
    [SerializeField] string closeDoorText;

    public override bool Interaction(Interaction interaction, PlayerInformation playerInformation)
    {
        textOpacity.fadeTime = 3f;
        if (!isOpened)
        {
            AudioSource.PlayClipAtPoint(interactSFX, transform.position);
            uiInfoText.text = infoText;

        }
        if (isOpened)
        {
            AudioSource.PlayClipAtPoint(interactSFX, transform.position);
            uiInfoText.text = closeDoorText;
        }
        isOpened = !isOpened;
        unityEvent?.Invoke(playerInformation);
        return true;
    }
}
