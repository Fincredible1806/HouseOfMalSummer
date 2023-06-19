using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractableListener
{
    public void StateChanged(AbstractInteractable interactable, PlayerInformation playerInformation);
}