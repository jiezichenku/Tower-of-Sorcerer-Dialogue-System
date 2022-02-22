using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class StoreAttribute
{
    public string Type;
    public string Money;
    public List<StoreGoodJson> Goods;
}

[System.Serializable]
public class StoreGoodJson
{
    public string Good;
    public int Value;
    public int Price;
}