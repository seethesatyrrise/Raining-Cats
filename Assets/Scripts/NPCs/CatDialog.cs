using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatDialog : DialogClass
{
    public override void UpdateDialog()
    {
        Debug.Log("cat");
        dialogText.text = "Caaat";
        if (GameManager.Instance.HatEnabled)
        {
            GameManager.Instance.PutHatOn();
        }
    }
}
