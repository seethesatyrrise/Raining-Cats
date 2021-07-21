using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenDialog : DialogClass
{
    public override void UpdateDialog()
    {
        Debug.Log("chicken");
        dialogText.text = "Chiiicken";
    }
}
