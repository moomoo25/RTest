using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CanvasMessageSetting : MonoBehaviour
{
    public GameObject canvas;
    public TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    public void SetMessage(string s)
    {
        textMeshProUGUI.text = s;
        StartCoroutine( CloseMessage(3));
    }
    private IEnumerator CloseMessage(float waitTime)
    {
        canvas.SetActive(true);
            yield return new WaitForSeconds(waitTime);
        canvas.SetActive(false);

    }

}
