using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogUIManager : MonoBehaviour
{
    [SerializeField] GameObject dialogImage;
    [SerializeField] GameObject mark;
    [SerializeField] GameObject itemPrefab;

    bool canActivateDialog;
    bool firstPass;

    void Start()
    {
        dialogImage.SetActive(false);
        canActivateDialog = false;
        firstPass = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canActivateDialog) 
        {
            dialogImage.SetActive(true);
            
            GameManager.Instance.PressEText(false);

            HideMark();

            if (firstPass)
            {
                GameManager.Instance.SpawnManager.SpawnItems(itemPrefab);
                firstPass = false;
            }
        }
    }

    private void HideMark()
    {
        mark.SetActive(false);
    }

    public void ShowMark()
    {
        mark.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.PressEText(true);
            canActivateDialog = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.PressEText(false);
            dialogImage.SetActive(false);
            canActivateDialog = false;
        }
    }
}
