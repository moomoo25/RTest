using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasKeySetting : MonoBehaviour
{
    public GameObject[] keys;

    public void AddKeyByIndex(int i)
    {
        keys[i].SetActive(true);
    }
}
