using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class GameManager : MonoBehaviour
{
    public static GameManager singletion;
    public ThirdPersonController thirdPersonController; 
    public InteractionManager interactionManager;
    private void Awake()
    {
        singletion = this;
    }
    public void TriggerPlayerMovement()
    {
        thirdPersonController.TriggerMovement();
        interactionManager.TriggerPlayerInteract();
    }
}
