using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    [SerializeField] private float sphereCastRadius;
    [SerializeField] private LayerMask interatableMask;
    [SerializeField] private float castDistance;
    [SerializeField] private int numFound;
    [SerializeField] PlayerInformation playerInformation;
    [SerializeField] GameObject camera;

    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            InteractionChecker();
        }
    }

    public void InteractionChecker()
    {
        // Checking for objects inside the Overlap sphere that it can interact with

        if (Physics.SphereCast(camera.transform.position, sphereCastRadius, transform.forward, out RaycastHit hit, castDistance, interatableMask))
        {
            var interactable = hit.collider.GetComponent<AbstractInteractable>();
            InteractTrigger(interactable);
            Debug.Log(hit.collider.name);
        }
    }

    private void InteractTrigger(AbstractInteractable interactable)
    {
        if (interactable != null)
        {
            Debug.Log("You interacted");
            interactable.Interaction(this, playerInformation);
        }
    }

    private void OnDrawGizmos()
    {
        // Drawing a gizmo for testing purposes
        Gizmos.color = Color.blue;
        Debug.DrawLine(camera.transform.position, camera.transform.position + transform.forward * castDistance);
        Gizmos.DrawWireSphere(camera.transform.position + transform.forward * castDistance, sphereCastRadius);
    }

}
