using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogClass : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI dialogText;
    protected GameManager manager;

    private void Awake()
    {
        dialogText = gameObject.GetComponent<TextMeshProUGUI>();
        manager = GameManager.Instance;
    }

    public virtual void UpdateDialog() { }

    private void OnEnable()
    {
        UpdateDialog();
    }
}
