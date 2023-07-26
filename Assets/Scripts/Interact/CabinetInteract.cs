using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetInteract : Interactable
{
    public Transform frontPost;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    public override void Interact()
    {
        GameManager.singletion.thirdPersonController.transform.position = frontPost.transform.position;
        GameManager.singletion.OnHide();
        audioSource.PlayOneShot(audioClip);
    }
}
