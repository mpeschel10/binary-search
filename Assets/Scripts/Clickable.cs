using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    Color oldColor;
    Color hoverColor = new Color(0.2f, 0.2f, 0.8f);
    Material material = null;

    public void Hover()
    {
        if (material == null) material = GetComponent<MeshRenderer>().material;
        oldColor = material.color;
        material.color = hoverColor;
    }

    public void Unhover()
    {
        material.color = oldColor;
    }
}
