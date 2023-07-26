using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private PlayerInteraction playerInteraction;
    [SerializeField] private Interactable interactableObject;

    public void Setup(PlayerInteraction interact)
    {
        playerInteraction = interact;
    }
    public void TriggerPlayerInteract()
    {
        playerInteraction.canInteract = !playerInteraction.canInteract;
    }
    public void AddInteract(Interactable interactable)
    {
        interactableObject = interactable;
        CanvasSetting.singleton.EnableInteract();
    }
    public void RemoveInteract()
    {
        interactableObject = null;
        CanvasSetting.singleton.DisableAllCanvas();
    }
    public void OnInteract()
    {
        if (interactableObject != null)
        {
            interactableObject.Interact();
        }
    }
}
