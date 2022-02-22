using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

public class BraverStatus
{
    //Using singleton pattern
    private static BraverStatus singleIntance;
    public static BraverStatus GetInstance()
    {
        if (singleIntance == null)
        {
            singleIntance = new BraverStatus();
        }
        return singleIntance;
    }
    public static BraverStatus GetInstance(BraverAttribute at)
    {
        if (singleIntance == null)
        {
            singleIntance = new BraverStatus();
        }
        singleIntance.attributes = at;
        return singleIntance;
    }
    // private List<string> attributes;
    private BraverAttribute attributes;
    public BraverAttribute getAttributes()
    {
        return attributes;
    }
    //singleton instance
    Repository repository;
    private BraverStatus()
    {
        attributes = Model.GetInitBraverData();
        repository = Repository.GetInstance();
        foreach(InitItemJson item in attributes.Items)
        {
            repository.UpdateItem(item.itemID, item.num);
        }
    }
    // Update appoint attribute value to old value add num
    public void UpdateStatus(string attribute, int num)
    {
        int value = attributes.GetAttribute(attribute);
        attributes.SetAttribute(attribute, num + value);
        EventCenter.Broadcast(EventType.StatusUpdate);
        return;
    }
    // Set appoint attribute valut to num
    public void SetStatus(string attribute, int num)
    {
        attributes.SetAttribute(attribute, num);
        EventCenter.Broadcast(EventType.StatusUpdate);
    }
}
