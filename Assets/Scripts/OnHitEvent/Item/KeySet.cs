using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySet : Item
{
    public int yellowKeyNum;
    public int buleKeyNum;
    public int redKeyNum;
    private Repository repository;
    public override void onHitEvent()
    {
        repository = Repository.GetInstance();
        repository.UpdateItem(1, yellowKeyNum);
        repository.UpdateItem(2, buleKeyNum);
        repository.UpdateItem(3, redKeyNum);
        remove();
    }
}
