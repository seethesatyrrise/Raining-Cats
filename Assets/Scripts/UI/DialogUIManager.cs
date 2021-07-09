using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogUIManager : MonoBehaviour
{
    [SerializeField] GameObject dialogImage;
    [SerializeField] TMP_Text eText;

    bool canActivateDialog;

    // Start is called before the first frame update
    void Start()
    {
        dialogImage.SetActive(false);
        eText.gameObject.SetActive(false);
        canActivateDialog = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canActivateDialog) 
        {
            dialogImage.SetActive(true);
            eText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eText.gameObject.SetActive(true);
            canActivateDialog = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eText.gameObject.SetActive(false);
            dialogImage.SetActive(false);
            canActivateDialog = false;
        }
    }
}
