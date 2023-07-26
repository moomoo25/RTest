using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class GameManager : MonoBehaviour
{
    public static GameManager singletion;
    public ThirdPersonController thirdPersonController; 
    public InteractionManager interactionManager;
    public GameObject playerMesh;
    public bool isPlayerHide;
    [Header("Keys")]
    public bool hasRedKey;
    public bool hasBlueKey;
    public bool hasYellowKey;

     private GameState gameState = GameState.findkey;
    private void Awake()
    {
        singletion = this;
    }
    public void TriggerPlayerMovement()
    {
        thirdPersonController.TriggerMovement();
        interactionManager.TriggerPlayerInteract();
    }
    public void OnHide()
    {
        thirdPersonController.TriggerMovement();
        playerMesh.SetActive(!playerMesh.activeInHierarchy);
        isPlayerHide = !playerMesh.activeInHierarchy;
    }
    public void AddKey(int i)
    {
        CanvasSetting.singleton.AddKey(i);
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
        CheckKey();
    }
    public bool CheckKey()
    {
        if(hasRedKey && hasBlueKey && hasYellowKey)
        {
            gameState = GameState.exit;
            CanvasSetting.singleton.ChangeObjective("Go to green zone");
            return true;
        }
        return false;
    }
    enum GameState
    {
        findkey,exit,end
    }
}
