using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteract : Interactable
{
    public int keyIndex = 2;
    public override void Interact()
    {
        GameManager.singletion.AddKey(keyIndex);
        GameManager.singletion.interactionManager.RemoveInteract();
        Destroy(this.gameObject);
    }
}
