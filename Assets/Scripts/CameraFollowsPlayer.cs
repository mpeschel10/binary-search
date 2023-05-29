using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour
{
    [SerializeField] Transform leaderTransform;
    void Update()
    {
        transform.position = leaderTransform.position;
    }
}
