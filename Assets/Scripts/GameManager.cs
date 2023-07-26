using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager singletion;
    public ThirdPersonController thirdPersonController;
    public Zombie zombie;
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
    public void ChasePlayer()
    {
        zombie.state = Zombie.State.superchase;
    }
    public void EndGame(string text)
    {
        if (gameState == GameState.end)
            return;

        thirdPersonController.TriggerMovement();
        gameState = GameState.end;
        zombie.state = Zombie.State.end;
        CanvasSetting.singleton.EnableEndGameCanvas(text);
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
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    enum GameState
    {
        findkey,exit,end
    }
}
