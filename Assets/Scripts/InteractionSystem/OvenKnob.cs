using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenKnob : AbstractInteractable
{
    public int orderNum;
    [SerializeField] string ovenId;
    public bool locked = false;


    public override bool Interaction(Interaction interaction, PlayerInformation playerInformation)
    {
        if (!locked)
        {
            if (EnvironmentInformation.instance.environmentalStateObjects.TryGetValue(ovenId, out AbstractStateObject ovenObject))
            {
                ovenObject.StateChanged(this, playerInformation);
            }
            textOpacity.fadeTime = 3f;
            uiInfoText.text = infoText;
            unityEvent?.Invoke(playerInformation);
            source.PlayOneShot(interactSFX);
            return true;
        }
        return false;
    }
}
