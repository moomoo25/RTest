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
    public bool hasBlueKey;
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
    public void AddKey(int i)
    {
        if (i == 0)
        {
            hasYellowKey = true;
        }
        else if (i == 1)
        {
            hasRedKey = true;
        }
        else
        {
            hasBlueKey = true;
        }
    }
    public bool CheckKey()
    {
        if(hasRedKey && hasBlueKey && hasYellowKey)
        {
            return true;
        }
        return false;
    }
}
