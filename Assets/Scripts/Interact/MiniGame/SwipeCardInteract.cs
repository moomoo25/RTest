using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeCardInteract : Interactable
{
    public override void Interact()
    {
        CanvasSetting.singleton.EnableSwipeCard();
    }
}
