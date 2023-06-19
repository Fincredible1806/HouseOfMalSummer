using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
public class PlantPot : AbstractInteractable
{
    [SerializeField] GameObject plantPot1;
    [SerializeField] GameObject plantPot2;

    public override bool Interaction(Interaction interaction, PlayerInformation playerInformation)
    {
        AudioSource.PlayClipAtPoint(interactSFX, transform.position);
        plantPot1.SetActive(!plantPot1.active);
        plantPot2.SetActive(!plantPot2.active);
        textOpacity.fadeTime = 3f;
        uiInfoText.text = infoText;
        unityEvent?.Invoke(playerInformation);
        return true;
    }

}
