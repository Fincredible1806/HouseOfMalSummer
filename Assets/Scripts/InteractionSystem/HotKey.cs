using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HotKey: AbstractInteractable
{
    [SerializeField] private bool isHot;
    [SerializeField] private string coolingItem;
    [SerializeField] private string hotText;
    private void Awake()
    {
        isHot = true;
    }
    public override bool Interaction(Interaction interaction, PlayerInformation playerInformation)
    {
        if (playerInformation.playerInventory.ContainsKey(coolingItem))
        {
            isHot = false;
        }
        if (!isHot)
        {
            AudioSource.PlayClipAtPoint(interactSFX, transform.position);
            playerInformation.playerInventory.Add(id, this);
            textOpacity.fadeTime = 3f;
            uiInfoText.text = infoText;
            unityEvent?.Invoke(playerInformation);
            Destroy(gameObject);
            return true;
        }
        else
        {
            textOpacity.fadeTime = 3f;
            uiInfoText.text = hotText;
        }
        return true;
    }
}
