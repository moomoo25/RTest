using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : Interactable
{
    public override void Interact()
    {
        if (GameManager.singletion.CheckKey())
        {
            CanvasSetting.singleton.EnableMessage("Run to exit");
            Destroy(this.gameObject);
        }
        else
        {
            CanvasSetting.singleton.EnableMessage("Find 3 keys");
        }
    }
}
