using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelector : MonoBehaviour
{
    public float selectionRange;
    public LayerMask selectableMask;
    Color oldColor;
    public Color selectedColor;

    void Update()
    {
        Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, selectionRange, selectableMask);
        
        DoOutlines(hitInfo);
        DoClicks(hitInfo);
    }

    Outline outline;
    void DoOutlines(RaycastHit hitInfo)
    {
        if ((outline == null && hitInfo.collider == null) ||
            (hitInfo.collider != null && outline != null && hitInfo.collider.gameObject == outline.gameObject))
            // Nothing has changed, so don't flip-flop the outline.
            return;

        if (outline != null)
        {
            outline.SubtractLayer("can-click");
            outline = null;
        }

        if (hitInfo.collider != null)
        {
            outline = hitInfo.collider.gameObject.GetComponent<Outline>();
            if (outline == null)
            {
                Debug.LogError("gameObject " + hitInfo.collider.gameObject + " on selectable layer has no Outline component.");
                return;
            }
            outline.AddLayer("can-click");
        }
    }

    void DoClicks(RaycastHit hitInfo)
    {
        if (hitInfo.collider != null && Input.GetMouseButtonDown(0))
        {
            GameObject gameObject = hitInfo.collider.gameObject;
            if (gameObject.TryGetComponent(out HiddenTile hiddenTile))
            {
                hiddenTile.click();
            } else {
                Debug.LogError("gameObject " + hitInfo.collider.gameObject + " on selectable layer has no clickable component e.g. HiddenTile.");
                return;
            }
        }
    }
}
