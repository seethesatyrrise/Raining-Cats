using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenDialog : DialogClass
{
    public override void UpdateDialog()
    {
        //Debug.Log("chicken");
        //dialogText.text = "Chiiicken";
        if (manager.HatIsOn) // when hat is on fox
        {
            dialogText.text = "�� � ������! ��� ����� �������...";
        }
        else if (manager.HatEnabled) // when you need to take a hat from cat
        {
            dialogText.text = "���� ������ � ����!";
        }
        else if (manager.ApplesCount >= 4) // when you collect enough items for this NPC, but not for others
        {
            dialogText.text = "����� ��� ����������, ������ ������.";
        }
        else if (manager.ApplesCount > 0) // when you collect not enough items for this NPC
        {
            dialogText.text = "�������� ��� �������!";
        }
        else // when you first time talk to NPC or collect no items for it
        {
            dialogText.text = "������! � ������� ������, ��������? ����� ��� 4 �����.";
        }
    }
}
