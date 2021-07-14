using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Transform cameraTransform;

    bool closeEnough;

    float minAngle = 10;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (closeEnough)
        {
            CheckForAttention();
        }
    }

    private void CheckForAttention()
    {
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 distance = transform.position - cameraTransform.position;
        float angle = Vector3.Angle(cameraForward, distance);

        if (angle < minAngle)
        {
            GameManager.Instance.GetAttention(transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            closeEnough = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.PressEText(false);
            closeEnough = false;
            GameManager.Instance.RemoveMark(transform);
        }
    }
}
