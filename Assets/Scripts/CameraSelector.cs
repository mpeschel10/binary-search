using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelector : MonoBehaviour
{
    public float selectionRange;
    public LayerMask selectableMask;
    GameObject selected = null;
    Color oldColor;
    Color clickColor;
    public Color selectedColor;

    void Update()
    {
        bool hit = Physics.Raycast(transform.position, transform.forward, out RaycastHit result, selectionRange, selectableMask);

        // Options:
        //  If we were selecting something last frame and are selelecting something now, is it the same thing?
        //  I worry that flopping the color around every frame will cause trouble.
        //  So:
        //  last_frame | this_frame | action
        //  --------------------------------
        //  null       | null       | pass
        //  a          | a          | pass
        //  null       | b          | select b
        //  a          | null       | deselect a
        //  a          | b          | deselect a, select b
        if ( (hit || selected != null) &&  (!hit || selected != result.collider.gameObject) )
        {
            if (selected != null) deselect_old();
            if (hit) select(result.collider.gameObject);
        }

        if (selected != null && Input.GetMouseButtonDown(0))
        {
            if (selected.TryGetComponent(out HiddenTile hiddenTile))
            {
                selected.GetComponent<Renderer>().material.color = oldColor;
                hiddenTile.click();
                selected = null;
            }
        }
    }

    void deselect_old()
    {
        selected.GetComponent<Renderer>().material.color = oldColor;
        selected = null;
    }

    void select(GameObject gameObject)
    {
        selected = gameObject;
        oldColor = selected.GetComponent<Renderer>().material.color;
        selected.GetComponent<Renderer>().material.color = selectedColor;
    }
}
