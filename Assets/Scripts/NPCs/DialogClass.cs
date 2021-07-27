using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogClass : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI dialogText;

    private void Awake()
    {
        dialogText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    public virtual void UpdateDialog() { }

    private void OnEnable()
    {
        UpdateDialog();
    }
}
