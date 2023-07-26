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
    [Space(20)]
    [SerializeField] private CanvasNoteSetting canvasNoteSetting;
    [SerializeField] private CanvasMessageSetting canvasMessageSetting;
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
    public void EnableMessage(string text)
    {
        if (messageCanvas.activeInHierarchy)
            return;
        messageCanvas.SetActive(true);
        canvasMessageSetting.SetMessage(text);
    }
    public void DisableAllCanvas()
    {
        interactCanvas.SetActive(false);
        noteCanvas.SetActive(false);
        messageCanvas.SetActive(false);
    }
}
