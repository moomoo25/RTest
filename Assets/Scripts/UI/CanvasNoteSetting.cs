using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CanvasNoteSetting : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    public void SetNote(string s)
    {
        textMeshProUGUI.text = s;
    }
    public void CloseNote()
    {
        textMeshProUGUI.text = "";
        this.gameObject.SetActive(false);
    }
}
