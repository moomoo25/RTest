using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;
public class PlayerCrouch : MonoBehaviour
{
    [SerializeField] private ThirdPersonController thirdPersonController = null;
    public InputAction playerInput;
    private void OnEnable()
    {
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
        thirdPersonController.SetCrouch();
    }
}
