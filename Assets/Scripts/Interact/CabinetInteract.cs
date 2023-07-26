using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetInteract : Interactable
{
    public Transform frontPost;
    public override void Interact()
    {
        GameManager.singletion.thirdPersonController.transform.position = frontPost.transform.position;
        GameManager.singletion.OnHide();
      
    }
}
