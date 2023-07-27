using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Password : MonoBehaviour
{
    public string password;
    public TMP_InputField inputField;
    public GameObject keyObject;
    public void CheckPassword()
    {
        if(inputField.text == password)
        {
           // Debug.Log("Correct");
            GameManager.singletion.AddKey(0);
            keyObject.SetActive(false);
            GameManager.singletion.interactionManager.RemoveInteract();
            CanvasSetting.singleton.DisablePassword();
            SoundManager.singleton.PlayCorrectSound();
        }
        else
        {
            //Debug.Log("Wrong");
            SoundManager.singleton.PlayWrongSound();
        }
    }
}
