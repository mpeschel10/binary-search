using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenTile : MonoBehaviour, CameraSelector.Hoverable
{
    int defaultLayer = 0;
    public void Click()
    {
        gameObject.layer = defaultLayer;
        gameObject.GetComponent<Outline>().AddLayer("clicked");
    }

    public void Hover()
    {
        gameObject.GetComponent<Outline>().AddLayer("can-click");
    }
    public void Unhover()
    {
        gameObject.GetComponent<Outline>().SubtractLayer("can-click");
    }
    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
