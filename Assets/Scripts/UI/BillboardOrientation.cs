using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardOrientation : MonoBehaviour
{
    Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cameraTransform);
        transform.Rotate(transform.eulerAngles.x, 180, transform.eulerAngles.z);
        //transform.forward = new Vector3(0, cameraTransform.forward.y, 0);
    }
}
