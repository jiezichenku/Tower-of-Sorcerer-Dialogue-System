using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SaveData
{
    private string currentSceneName;
    private Vector3 braverPosition;
    private BraverAttribute braverAttribute;
    private List<int> items;
    private Dictionary<string, List<Vector2>> destroyedObjects;
    private Dictionary<EventType, Delegate> eventTable;

    public SaveData(string n, Vector3 bp, BraverAttribute ba, List<int> i, Dictionary<string, List<Vector2>> d, Dictionary<EventType, Delegate> et)
    {
        currentSceneName = n;
        braverPosition = bp;
        braverAttribute = ba;
        items = i;
        destroyedObjects = d;
        eventTable = et;
    }

    public string getCurrentSceneName()
    {
        return currentSceneName;
    }
    public Vector3 getBraverPosition()
    {
        return braverPosition;
    }
    public BraverAttribute getBraverAttribute()
    {
        return braverAttribute;
    }
    public List<int> getItems()
    {
        return items;
    }
    public Dictionary<string, List<Vector2>> getDestroyedObjects()
    {
        return destroyedObjects;
    }
    public Dictionary<EventType, Delegate> getEventTable()
    {
        return eventTable;
    }
}
