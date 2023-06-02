using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelector : MonoBehaviour
{
    public interface Hoverable {
        public void Hover(); public void Unhover();
        public GameObject GetGameObject(); // Interfaces cannot expose instance fields...
    }
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

    Hoverable hoverable;
    void DoOutlines(RaycastHit hitInfo)
    {
        if ((hoverable == null && hitInfo.collider == null) ||
            (hitInfo.collider != null && hoverable != null && hitInfo.collider.gameObject == hoverable.GetGameObject()))
            return; // Nothing has changed, so don't flip-flop the outline.

        if (hoverable != null)
        {
            hoverable.Unhover();
            hoverable = null;
        }

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out hoverable))
            {
                hoverable.Hover();
            } else  {
                Debug.LogError("gameObject " + hitInfo.collider.gameObject + " on selectable layer has no Hoverable");
            }
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
