using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ItemAttribute
{
    public List<ItemInfoJson> Info;
}
[System.Serializable]
public class ItemInfoJson
{
    public int itemID;
    public string itemName;
}