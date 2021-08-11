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
            dialogText.text = "���� ����!";
        } else if (manager.HatEnabled) // when you need to take a hat from cat
        {
            dialogText.text = "�� ��� ��� �������! ����� �����!";
            manager.PutHatOn();
        } else if (manager.MilkCount >= 4) // when you collect enough items for this NPC, but not for others
        {
            dialogText.text = "������ ����������, ������ ������.";
        } else if (manager.MilkCount > 0) // when you collect not enough items for this NPC
        {
            dialogText.text = "���-�� �������, ���������.";
        } else // when you first time talk to NPC or collect no items for it
        {
            dialogText.text = "������, ���! ������ ��� ������� ������. ��� ����� 4 ��������.";
        }
    }
}
