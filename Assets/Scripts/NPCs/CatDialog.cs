using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatDialog : DialogClass
{
    public override void UpdateDialog()
    {
        //Debug.Log("cat");
        //dialogText.text = "Caaat";
        if (manager.HatIsOn) // when hat is on fox
        {
            dialogText.text = "Тебе идет!";
        } else if (manager.HatEnabled) // when you need to take a hat from cat
        {
            dialogText.text = "Ты как раз вовремя! Держи шляпу!";
            manager.PutHatOn();
        } else if (manager.MilkCount >= 4) // when you collect enough items for this NPC, but not for others
        {
            dialogText.text = "Молока достаточно, помоги другим.";
        } else if (manager.MilkCount > 0) // when you collect not enough items for this NPC
        {
            dialogText.text = "Что-то темнеет, ускоряйся.";
        } else // when you first time talk to NPC or collect no items for it
        {
            dialogText.text = "Привет, Лис! Помоги мне собрать молоко. Мне нужно 4 упаковки.";
        }
    }
}
