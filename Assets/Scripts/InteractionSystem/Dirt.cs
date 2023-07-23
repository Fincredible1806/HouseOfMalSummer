using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
public class Dirt : AbstractInteractable
{
    [SerializeField] string diggableDirt;
    public bool locked { get; set; }
    [SerializeField] string shovelId;
    public Animator animator;

    private void Awake()
    {
        locked = true;
    }


    public override bool Interaction(Interaction interaction, PlayerInformation playerInformation)
    {
        if (playerInformation.playerInventory.ContainsKey(shovelId))
        {
            locked = false;
        }
        if (!locked)
        {
            AudioSource.PlayClipAtPoint(interactSFX, transform.position);
            textOpacity.fadeTime = 3f;
            uiInfoText.text = diggableDirt;
            unityEvent?.Invoke(playerInformation);
            Destroy(gameObject, 0.5f);
        }
        else
        {
            textOpacity.fadeTime = 3f;
            uiInfoText.text = infoText;
        }
        return true;
    }

}
