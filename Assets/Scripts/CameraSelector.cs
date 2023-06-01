using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelector : MonoBehaviour
{
    public float selectionRange;
    public LayerMask selectableMask;
    Color oldColor;
    public Color selectedColor;

    Outline outline;

    void Update()
    {
        if (outline != null)
        {
            outline.SubtractLayer("can-click");
            outline = null;
        }

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, selectionRange, selectableMask))
        {
            outline = hitInfo.collider.gameObject.GetComponent<Outline>();
            if (outline == null) Debug.LogError("gameObject " + hitInfo.collider.gameObject + " on selectable layer has no Outline component.");
            outline.AddLayer("can-click");
        }
    }
}
