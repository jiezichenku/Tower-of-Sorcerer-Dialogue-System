using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : OnHitEvent
{
    public int storeID;
    public override void onHitEvent()
    {
        PanelManager manager = PanelManager.GetInstance();
        manager.Push(new StorePanel(storeID));
    }
}
