using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class NoteInteract : AbstractInteractable
{
    [SerializeField] TMP_Text noteText;
    public override bool Interaction(Interaction interaction, PlayerInformation playerInformation)
        {
            playerInformation.noteInfos.Add(noteText.text);
            playerInformation.playerInventory.Add(id, this);
            AudioSource.PlayClipAtPoint(interactSFX, transform.position);
            textOpacity.fadeTime = 3f;
            uiInfoText.text = infoText;
            unityEvent?.Invoke(playerInformation);
            Destroy(gameObject);
            return true;

        }
}