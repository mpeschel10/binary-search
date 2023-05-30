using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenTile : MonoBehaviour
{
    Color clickColor = new Color(0.5f, 0.5f, 0f);
    int defaultLayer = 0;
    public void click()
    {
        GetComponent<Renderer>().material.color = clickColor;
        gameObject.layer = defaultLayer;
    }

}
