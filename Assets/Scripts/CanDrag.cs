using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanDrag : MonoBehaviour, CameraSelector.Hoverable
{
    public GameObject GetGameObject() { return gameObject; }
    public void Hover() { GetComponent<Outline>().AddLayer("can-drag"); }
    public void Unhover() { GetComponent<Outline>().SubtractLayer("can-drag"); }

}
