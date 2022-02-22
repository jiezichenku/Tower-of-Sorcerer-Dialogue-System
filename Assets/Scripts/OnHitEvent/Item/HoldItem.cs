using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItem : Item
{
    public override void onHitEvent()
    {
        Repository repository = Repository.GetInstance();
        if (repository.CheckItem(itemID, 1))
        {
            use(1);
        }
        
        repository.UpdateItem(itemID, -1);
    }

    public virtual void use(int num)
    {

    }
}
