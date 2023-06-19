using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : AbstractStateObject
{
    [SerializeField]
    List<int> knobSequence = new List<int>();
    [SerializeField] AnimationHandler animationHandler;
    private List<int> currentInputs = new List<int>();
    [SerializeField] EnvironmentInformation environmentInformation;
    [SerializeField] string doorBool;
    List<OvenKnob> ovenKnobs = new List<OvenKnob>();
    [SerializeField] GameObject[] fireRings;
    bool sequenceHit = true;
    public GameObject oven;
    private MeshCollider ovenCollider;
    private void Start()
    {
        EnvironmentInformation.instance.RegisterStateObject(this);
    }
    public override void StateChanged(AbstractInteractable interactable, PlayerInformation playerInformation)
    {
        OvenKnob knob = interactable as OvenKnob;
        if (knob == null) return;

        currentInputs.Add(knob.orderNum);
        if (!ovenKnobs.Contains(knob))
        {
            ovenKnobs.Add(knob);

        }
        if (currentInputs.Count < knobSequence.Count) return;

        Debug.Log(currentInputs.Count);
        sequenceHit = true;
        for (int i = 0; i < currentInputs.Count; ++i)
        {
           

            if (knobSequence[i] != currentInputs[i])
            {
                sequenceHit = false;
                HobOff();
                currentInputs.Clear();
                break;
            }
        }

        if (sequenceHit)
        {
            foreach (OvenKnob knobToLock in ovenKnobs)
            {
                knobToLock.locked = true;
            }
            animationHandler.ToggleBool(doorBool);
            ovenCollider = oven.GetComponent<MeshCollider>();
            ovenCollider.enabled = false;
            
            Invoke("HobOff", Time.deltaTime);
        }
    }

    private void HobOff()
    {
        foreach (GameObject fireRing in fireRings)
        {
            fireRing.SetActive(false);
        }
    }
    public void ResetTheOven()
    {
        HobOff();
        currentInputs.Clear();
        Debug.Log(currentInputs.Count);
    }
}