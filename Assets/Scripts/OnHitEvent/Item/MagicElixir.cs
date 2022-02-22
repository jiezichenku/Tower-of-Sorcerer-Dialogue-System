using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicElixir : Item
{
    public override void onHitEvent()
    {
        BraverAttribute status = BraverStatus.GetInstance().getAttributes();
        int health = status.GetAttribute("Health");
        BraverStatus.GetInstance().UpdateStatus("Health", health);
        remove();
    }
}
