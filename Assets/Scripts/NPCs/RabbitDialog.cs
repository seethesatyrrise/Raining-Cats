using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitDialog : DialogClass
{
    public override void UpdateDialog()
    {
        Debug.Log("rabbit");
        dialogText.text = "Raaabbit";
    }
}
