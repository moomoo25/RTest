using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInteraction : MonoBehaviour
{
    public bool canInteract;
    public InputAction playerInput;
    private void OnEnable()
    {
        GameManager.singletion.interactionManager.Setup(this);

        playerInput.Enable();
        playerInput.performed += OnPressed;
    }
    private void OnDisable()
    {
        playerInput.Disable();
        playerInput.performed -= OnPressed;
    }

    public void OnPressed(InputAction.CallbackContext context)
    {
        if (canInteract == false)
            return;

        GameManager.singletion.interactionManager.OnInteract();
    }
    private void OnTriggerEnter(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null)
        {
            GameManager.singletion.interactionManager.AddInteract(interactable);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null)
        {
            GameManager.singletion.interactionManager.RemoveInteract();
        }
    }

}
