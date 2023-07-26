using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : Interactable
{
    [SerializeField] private string text; 
    public override void Interact()
    {
        CanvasSetting.singleton.EnableNote(text);
    }
}
