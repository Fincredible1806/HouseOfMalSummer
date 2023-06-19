using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentInformation : MonoBehaviour
{
    public static EnvironmentInformation instance;
    public Dictionary<string, AbstractInteractable> environmentalInteractables = new Dictionary<string, AbstractInteractable>();
    public Dictionary<string, AbstractStateObject> environmentalStateObjects = new Dictionary<string, AbstractStateObject>();

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        else
        {
            instance = this;
        }
    }

    public void RegisterInteractable(AbstractInteractable interactable)
    {
        environmentalInteractables.Add(interactable.id, interactable);
    }

    public void UnRegisterInteractable(AbstractInteractable interactable)
    {
        environmentalInteractables.Remove(interactable.id);
    }

    public void RegisterStateObject(AbstractStateObject stateObject)
    {
        environmentalStateObjects.Add(stateObject.id, stateObject);
    }

    public void UnRegisterStateObject(string id, AbstractStateObject stateObject)
    {
        environmentalStateObjects.Remove(id);
    }
}
