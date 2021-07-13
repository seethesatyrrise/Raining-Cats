using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }
}
