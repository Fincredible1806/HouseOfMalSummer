using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractablePickupObject : AbstractInteractable
{
    public AudioClip pickUpVoiceLine;
    public bool isAVoiceTrigger;
    public VoiceActTrigger voiceActTrigger;
    public GameObject particlePrefab;
    public override bool Interaction(Interaction interaction, PlayerInformation playerInformation)
    {
        Instantiate(particlePrefab, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(interactSFX, transform.position);
        playerInformation.playerInventory.Add(id, this);
        textOpacity.fadeTime = 3f;
        uiInfoText.text = infoText;
        unityEvent?.Invoke(playerInformation);
        if(isAVoiceTrigger)
        {
            voiceActTrigger.voiceClip = pickUpVoiceLine;
            voiceActTrigger.PlayNewClip();
        }
        Destroy(gameObject);
        return true;

    }
}
