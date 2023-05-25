using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    [SerializeField] float speedX;
    [SerializeField] float speedY;
    [SerializeField] float speedZ;
    // Update is called once per frame
    void Update()
    {
        Quaternion old = transform.rotation;
        Vector3 rotation = new Vector3(speedX, speedY, speedZ) * 360 * Time.deltaTime;
        transform.Rotate(rotation);
    }
}
