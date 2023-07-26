using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeInteract : Interactable
{
    public override void Interact()
    {
        GameManager.singletion.EndGame("Escaped!");
    }
}
