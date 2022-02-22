using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : Item
{
    public override void onHitEvent()
    {
        BraverAttribute status = BraverStatus.GetInstance().getAttributes();
        int health = status.GetAttribute("Health");
        int attack = status.GetAttribute("Attack");
        int defence = status.GetAttribute("Defence");
        health = health / 3;
        attack = attack / 3;
        defence = defence / 3;
        BraverStatus.GetInstance().UpdateStatus("Health", health);
        BraverStatus.GetInstance().UpdateStatus("Attack", attack);
        BraverStatus.GetInstance().UpdateStatus("Defence", defence);
        remove();
    }
}
