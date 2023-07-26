using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CanvasObjectiveSetting : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public void ChangeText(string text)
    {
        textMesh.text = text;
    }
}
