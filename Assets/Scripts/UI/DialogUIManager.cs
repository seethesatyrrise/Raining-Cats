using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogUIManager : MonoBehaviour
{
    [SerializeField] GameObject dialogImage;
    [SerializeField] GameObject eText;

    bool canActivateDialog;

    private void Awake()
    {
        eText = GameObject.Find("PressE");
    }

    void Start()
    {
        dialogImage.SetActive(false);
        canActivateDialog = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canActivateDialog) 
        {
            dialogImage.SetActive(true);
            eText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eText.SetActive(true);
            canActivateDialog = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eText.SetActive(false);
            dialogImage.SetActive(false);
            canActivateDialog = false;
        }
    }
}
