using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HiddenTile : MonoBehaviour, CameraSelector.Hoverable
{
    int defaultLayer = 0;
    TMP_Text face;
    [SerializeField] string hiddenText;

    void Start()
    {
        face = GetComponentInChildren<TMP_Text>();
    }
    public void Click()
    {
        gameObject.layer = defaultLayer;
        face.text = hiddenText;
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
