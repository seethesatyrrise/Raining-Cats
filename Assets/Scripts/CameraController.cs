using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player;
    Vector3 positionOffset;
    Vector3 rotationOffset;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        transform.SetParent(player);
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;

        rotationOffset = new Vector3(-10, 0, 0);
        positionOffset = new Vector3(0, 0.5f, -2);
        transform.position = transform.TransformPoint(player.position + positionOffset);
    }

    void LateUpdate()
    {
        transform.LookAt(player);
        transform.Rotate(rotationOffset);
    }
}
