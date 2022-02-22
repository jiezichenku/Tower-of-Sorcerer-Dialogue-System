using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeItem : Item
{
    public int Health;
    public int Attack;
    public int Defence;
    public int Shield;
    public int Gold;
    public int Experience;
    public override void onHitEvent()
    {
        BraverStatus status = BraverStatus.GetInstance();
        if (Health != 0)
        {
            status.UpdateStatus("Health", Health);
        }
        if (Attack != 0)
        {
            status.UpdateStatus("Attack", Attack);
        }
        if (Defence != 0)
        {
            status.UpdateStatus("Defence", Defence);
        }
        if (Shield != 0)
        {
            status.UpdateStatus("Shield", Shield);
        }
        if (Gold != 0)
        {
            status.UpdateStatus("Gold", Gold);
        }
        if (Experience != 0)
        {
            status.UpdateStatus("Experience", Experience);
        }
        remove();
    }
}
