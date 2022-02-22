using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BraverAttribute
{
    public int Health,
    Attack,
    Defence,
    Shield,
    Experience,
    Gold,
    Floor;

    public List<InitItemJson> Items; 

    public void SetAttribute(string attribute, int num)
    {
        this.GetType().GetField(attribute).SetValue(this, num);
    }

    public int GetAttribute(string attribute)
    {
        return int.Parse(this.GetType().GetField(attribute).GetValue(this).ToString());
    }
}
[System.Serializable]
public class InitItemJson
{
    public int itemID;
    public int num;
};