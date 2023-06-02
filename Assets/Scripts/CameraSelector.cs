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

    GameObject hovering;
    void DoOutlines(RaycastHit hitInfo)
    {
        if ((hovering == null && hitInfo.collider == null) ||
            (hitInfo.collider != null && hovering != null && hitInfo.collider.gameObject == hovering))
            return; // Nothing has changed, so don't flip-flop the outline.

        if (hovering != null)
        {
            hovering.GetComponent<HiddenTile>().Unhover();
            hovering = null;
        }

        if (hitInfo.collider != null)
        {
            GameObject gameObject = hitInfo.collider.gameObject;
            if (gameObject.TryGetComponent(out HiddenTile hiddenTile))
            {
                hiddenTile.Hover();
            } else {
                Debug.LogError("gameObject " + hitInfo.collider.gameObject + " on selectable layer has no hoverable component e.g. HiddenTile.");
                return;
            }
            hovering = gameObject;
        }
    }

    void DoClicks(RaycastHit hitInfo)
    {
        if (hitInfo.collider != null && Input.GetMouseButtonDown(0))
        {
            GameObject gameObject = hitInfo.collider.gameObject;
            if (gameObject.TryGetComponent(out HiddenTile hiddenTile))
            {
                hiddenTile.Click();
            } else {
                Debug.LogError("gameObject " + hitInfo.collider.gameObject + " on selectable layer has no clickable component e.g. HiddenTile.");
                return;
            }
        }
    }
}
