using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class GameManager : MonoBehaviour
{
    public static GameManager singletion;
    public ThirdPersonController thirdPersonController; 
    public InteractionManager interactionManager;

    [Header("Keys")]
    public bool hasRedKey;
    public bool hasGreenKey;
    public bool hasYellowKey;

    private void Awake()
    {
        singletion = this;
    }
    public void TriggerPlayerMovement()
    {
        thirdPersonController.TriggerMovement();
        interactionManager.TriggerPlayerInteract();
    }
    public bool CheckKey()
    {
        if(hasRedKey && hasGreenKey && hasYellowKey)
        {
            return true;
        }
        return false;
    }
}
