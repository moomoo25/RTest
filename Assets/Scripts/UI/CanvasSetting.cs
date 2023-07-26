using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSetting : MonoBehaviour
{
    public static CanvasSetting singleton;
    [Header("Canvas")]
    [SerializeField] private GameObject interactCanvas;
    [SerializeField] private GameObject noteCanvas;
    [SerializeField] private GameObject messageCanvas;
    [SerializeField] private GameObject keyCanvas;
    [SerializeField] private GameObject passwordCanvas;
    [SerializeField] private GameObject colorCanvas;
    [Space(20)]
    [SerializeField] private CanvasNoteSetting canvasNoteSetting;
    [SerializeField] private CanvasMessageSetting canvasMessageSetting;
    [SerializeField] private CanvasKeySetting canvasKeySetting;
    [SerializeField] private Password canvasPasswordSetting;
    [SerializeField] private CanvasObjectiveSetting canvasObjective;
    private void Awake()
    {
        singleton = this;
        DisableAllCanvas();
    }
    public void EnableInteract()
    {
        interactCanvas.SetActive(true);
    }
    public void DisableInteract()
    {
        interactCanvas.SetActive(false);
    }
    public void EnableNote(string text)
    {
        GameManager.singletion.TriggerPlayerMovement();
        canvasNoteSetting.SetNote(text);
        noteCanvas.SetActive(true);
    }
    public void DisableNote()
    {
        GameManager.singletion.TriggerPlayerMovement();
        noteCanvas.SetActive(false);
    }
    public void EnablePassword()
    {
        GameManager.singletion.TriggerPlayerMovement();
        passwordCanvas.SetActive(true);
    }
    public void DisablePassword()
    {
        GameManager.singletion.TriggerPlayerMovement();
        passwordCanvas.SetActive(false);
    }
    public void EnableColor()
    {
        GameManager.singletion.TriggerPlayerMovement();
        colorCanvas.SetActive(true);
    }
    public void DisableColor()
    {
        GameManager.singletion.TriggerPlayerMovement();
        colorCanvas.SetActive(false);
    }
    public void EnableMessage(string text)
    {
        if (messageCanvas.activeInHierarchy)
            return;
        messageCanvas.SetActive(true);
        canvasMessageSetting.SetMessage(text);
    }
    public void AddKey(int i)
    {
        canvasKeySetting.AddKeyByIndex(i);
    }
    public void ChangeObjective(string text)
    {
        canvasObjective.ChangeText(text);
    }
    public void DisableAllCanvas()
    {
        colorCanvas.SetActive(false);
        interactCanvas.SetActive(false);
        noteCanvas.SetActive(false);
        messageCanvas.SetActive(false);
        passwordCanvas.SetActive(false);
    }
}
