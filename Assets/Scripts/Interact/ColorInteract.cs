using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorInteract : Interactable
{
    public override void Interact()
    {
        CanvasSetting.singleton.EnableColor();
    }

}
