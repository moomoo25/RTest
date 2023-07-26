using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSetting : MonoBehaviour
{
    public static CanvasSetting singleton;
    [Header("Canvas")]
    [SerializeField] private GameObject interactCanvas;
    [SerializeField] private GameObject noteCanvas;
    [Space(20)]
    [SerializeField] private CanvasNoteSetting canvasNoteSetting;
    private void Awake()
    {
        singleton = this;
        DisableAllCanvas();
    }
    public void EnableInteract()
    {
        interactCanvas.SetActive(true);
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
    public void DisableAllCanvas()
    {
        interactCanvas.SetActive(false);
        noteCanvas.SetActive(false);
    }
}
