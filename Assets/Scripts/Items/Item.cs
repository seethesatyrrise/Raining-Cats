using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    bool eButtonEnabled;

    [SerializeField] GameObject eText;

    Transform cameraTransform;

    bool gotMark;

    private void Awake()
    {
        eText = GameObject.Find("PressE");
        cameraTransform = Camera.main.transform;

        gotMark = false;
       // mark = Instantiate(markPrefab, transform.position + markOffset, Quaternion.identity, transform);
    }

    private void Start()
    {
        eText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (eButtonEnabled)
        {
            Vector3 cameraForward = cameraTransform.forward;
            Vector3 distance = transform.position - cameraTransform.position;
            float angle = Vector3.Angle(cameraForward, distance);

            if (angle < 10)
            {
                gotMark = true;
                GameManager.Instance.GetAttention(transform);
            }
            else gotMark = false;

            if (gotMark && Input.GetKeyDown(KeyCode.E))
            {
                GameManager.Instance.PickUpCountUp(gameObject.tag);
                eText.SetActive(false);
                GameManager.Instance.RemoveMark();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eText.SetActive(true);
            eButtonEnabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eText.SetActive(false);
            eButtonEnabled = false;
            if (gotMark)
            {
                GameManager.Instance.RemoveMark();
                gotMark = false;
            }
        }
    }
}
