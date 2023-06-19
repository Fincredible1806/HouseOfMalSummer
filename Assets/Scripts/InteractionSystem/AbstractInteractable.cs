using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class AbstractInteractable : MonoBehaviour, IInteractable
{
    // Setting variables and interaction for all interactable object classes to inherit from
    bool IInteractable.Interact(Interaction interaction, PlayerInformation playerInformation) => Interaction(interaction, playerInformation);
    public TextOpacity textOpacity;
    [SerializeField] public TMP_Text uiInfoText;
    [SerializeField] public string infoText;
    [SerializeField] protected PlayerInformationUnityEvent unityEvent;
    [SerializeField] protected string interactableId = "";
    public AudioSource source;
    public AudioClip interactSFX;

    public string id {
        set { interactableId = value; }
        get { return interactableId; }
    }


    public virtual bool Interaction(Interaction interaction, PlayerInformation playerInformation)
    {
        textOpacity.fadeTime = 3f;
        uiInfoText.text = infoText;
        unityEvent?.Invoke(playerInformation);
        AudioSource.PlayClipAtPoint(interactSFX, transform.position);
        return true;
    }
}