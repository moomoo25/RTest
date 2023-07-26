using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : Interactable
{
    bool moveDown;
    public override void Interact()
    {
        if (GameManager.singletion.CheckKey())
        {
            moveDown = true;
            CanvasSetting.singleton.EnableMessage("Run to exit");
            GameManager.singletion.ChasePlayer();
           // Destroy(this.gameObject);
        }
        else
        {
            CanvasSetting.singleton.EnableMessage("Find 3 keys");
        }
    }
    private void Update()
    {
        if (!moveDown)
            return;

        Vector3 v = transform.position;
        if (v.y > -10)
        {
            v.y = v.y - Time.deltaTime*5;
        }
        transform.position = v;
    }
}
