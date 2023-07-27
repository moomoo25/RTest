using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordInteract : Interactable
{
    public override void Interact()
    {
        CanvasSetting.singleton.EnablePassword();
    }
}
