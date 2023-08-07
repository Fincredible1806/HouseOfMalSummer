using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class TheBreakingWall : AbstractInteractable
{
    // Setting variables and interaction for all interactable object classes to inherit from
    public bool locked { get; set; }
    bool isBroken = false;
    [SerializeField] string noStuffText;
    [SerializeField] string noHammerText;
    [SerializeField] string smashDownText;
    [SerializeField] string noFloorPlanText;
    [SerializeField] string hammerId;
    [SerializeField] string floorPlanId;
    [SerializeField] Vector3 forceAttack;
    private void Awake()
    {
        locked = true;
    }

    public override bool Interaction(Interaction interaction, PlayerInformation playerInformation)
    {
        if(isBroken)
        {
            return false;
        }
        if (!playerInformation.playerInventory.ContainsKey(hammerId) &!playerInformation.playerInventory.ContainsKey(floorPlanId))
        {
            textOpacity.fadeTime = 3f;
            uiInfoText.text = noStuffText;
            return true;
        }

        if (!playerInformation.playerInventory.ContainsKey(hammerId))
        {
            uiInfoText.text = noHammerText;
        }
        
        if (!playerInformation.playerInventory.ContainsKey(floorPlanId))
        {
            uiInfoText.text = noFloorPlanText;
        }

        if (playerInformation.playerInventory.ContainsKey(hammerId) && playerInformation.playerInventory.ContainsKey(floorPlanId))
        {
            locked = false;
        }
        if (!locked && !isBroken)
        {
                uiInfoText.text = smashDownText;
                textOpacity.fadeTime = 3f;
                AudioSource.PlayClipAtPoint(interactSFX, transform.position);
                isBroken = true;

                foreach (Transform child in transform)
                {
                    Rigidbody rb = child.GetComponent<Rigidbody>();
                    rb.isKinematic = false;
                    rb.useGravity = true; 
                    rb.AddForce(forceAttack, ForceMode.VelocityChange);
                    Destroy(child.gameObject, 3.5f);
    
                }
                Debug.Log("Smashed it");
                unityEvent?.Invoke(playerInformation);
        }
        return true;
    }
}