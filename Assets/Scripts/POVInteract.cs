using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POVInteract : MonoBehaviour
{
    [SerializeField] GameObject playerCamera;
    [SerializeField] float clickDistance;
    [SerializeField] LayerMask clickMask;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hitInfo, clickDistance, clickMask))
            {
                GameObject selected = hitInfo.collider.gameObject;
                if (selected.TryGetComponent(out HiddenTile hiddenTile))
                {
                    hiddenTile.click();
                }
            }
        }
        // if (selected != null && Input.GetMouseButtonDown(0))
        // {
        // } else if (selected != null && Input.GetKeyDown("e"))
        // {
        //     if (selected.TryGetComponent(out Draggable draggable))
        //     {
        //         Debug.Log(draggable);
        //     }
        // }
    }
}
