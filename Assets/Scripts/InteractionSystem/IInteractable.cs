using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IInteractable
{
    public string id { get; set; }
    public bool Interact(Interaction interaction, PlayerInformation playerInformation);
}
