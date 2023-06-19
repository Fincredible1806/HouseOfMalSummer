using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractStateObject : MonoBehaviour, IInteractableListener
{
    void IInteractableListener.StateChanged(AbstractInteractable interactable, PlayerInformation playerInformation) => StateChanged(interactable, playerInformation);

    [SerializeField]
    public string id;

    public virtual void StateChanged(AbstractInteractable interactable, PlayerInformation playerInformation)
    {

    }
}