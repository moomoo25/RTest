using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMiniGame : MonoBehaviour
{
    public List<string> colorsPassword = new List<string>();
    public List<string> pass = new List<string>();
    public int colorIndex;
    public GameObject redKeyObject;
  
    public void RedButton()
    {
        pass.Add("red");
        CheckNext();
    }
    public void GreenButton()
    {
        pass.Add("green");
        CheckNext();
    }
    public void BlueButton()
    {
        pass.Add("blue");
        CheckNext();
    }
    void CheckNext()
    {
        if (pass[colorIndex] != colorsPassword[colorIndex])
        {
            pass.Clear();
            colorIndex = 0;
            return;
        }


        colorIndex++;
        if(colorIndex>colorsPassword.Count)
        {
            pass.Clear();
            colorIndex = 0;
            return;
        }
       bool isDone = checkPassword();

        if (isDone)
        {
            print("Done");
            CanvasSetting.singleton.DisableColor();
            GameManager.singletion.AddKey(1);
            SoundManager.singleton.PlayCorrectSound();
            GameManager.singletion.interactionManager.RemoveInteract();
            redKeyObject.SetActive(false);
        }
    }
    private bool checkPassword()
    {
        if (colorsPassword.Count != pass.Count)
            return false;
        int count=0;
        for (int i = 0; i < colorsPassword.Count; i++)
        {
            if (colorsPassword[i] == pass[i])
            {
                count++;
            }
        }
        if (count == 6)
            return true;
        else
            return false;
    }
}
