using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item
{
    private Repository repository;
    public override void onHitEvent()
    {
        repository = Repository.GetInstance();
        repository.UpdateItem(itemID, 1);
        remove();
    }
}
