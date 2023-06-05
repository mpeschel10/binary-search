using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisDraggable : MonoBehaviour, CameraSelector.Draggable
{
    public float dragSpeed = 10f;

    private Rigidbody rb;
    private Transform grabTransform;
    private Vector3 grabOffset;

    void Awake()
    {
        if (!TryGetComponent(out rb))
        {
            throw new System.Exception("AxisDraggable could not find rigidbody attached to component " + gameObject + ". Probably add that component?");
        }
    }
    public void Grab(Transform grabTransform)
    {
        this.grabTransform = grabTransform;
        this.grabOffset = grabTransform.position - this.transform.position;
    }

    public void Ungrab()
    {
        this.grabTransform = null;
    }

    private void FixedUpdate()
    {
        if (grabTransform != null)
        {
            rb.MovePosition(grabTransform.position - grabOffset);
        }
    }
}
