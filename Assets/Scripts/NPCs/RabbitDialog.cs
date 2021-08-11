using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitDialog : DialogClass
{
    public override void UpdateDialog()
    {
        //Debug.Log("rabbit");
        //dialogText.text = "Raaabbit";
        if (manager.HatIsOn) // when hat is on fox
        {
            dialogText.text = "Мечтаю о такой же шляпе, но мне не пойдет...";
        }
        else if (manager.HatEnabled) // when you need to take a hat from cat
        {
            dialogText.text = "Дождь вот-вот начнется, а ты еще не подошел к коту?";
        }
        else if (manager.BananasCount >= 4) // when you collect enough items for this NPC, but not for others
        {
            dialogText.text = "Ого, как быстро! Теперь помоги другим.";
        }
        else if (manager.BananasCount > 0) // when you collect not enough items for this NPC
        {
            dialogText.text = "Поищи еще, пожалуйста.";
        }
        else // when you first time talk to NPC or collect no items for it
        {
            dialogText.text = "Привет! Мне не хватает 4 бананов. Я боюсь не успеть до дождя. Поможешь мне?";
        }
    }
}
