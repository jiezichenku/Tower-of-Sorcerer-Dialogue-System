using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITool
{
    public GameObject activePanel { get; set; }
    private static UITool singleIntance;
    public static UITool GetInstance()
    {
        if (singleIntance == null)
        {
            singleIntance = new UITool();
        }
        return singleIntance;
    }
    private UITool()
    {

    }

    public T GetOrAddComponent<T>() where T: Component
    {
        if(activePanel.GetComponent<T>() == null)
        {
            activePanel.AddComponent<T>();
        }
        return activePanel.GetComponent<T>();
    }

    public GameObject FindChildGameObject(string name)
    {
        Transform[] trans = activePanel.GetComponentsInChildren<Transform>();

        foreach(Transform t in trans)
        {
            if (t.name == name)
            {
                return t.gameObject;
            }
        }
        Debug.LogWarning($"No child object called {name} in {activePanel.name}");
        return null;
    }

    public T GetOrAddComponentInChildren<T> (string name) where T : Component
    {
        GameObject child = FindChildGameObject(name);
        if (child != null)
        {
            if (child.GetComponent<T>() == null)
            {
                child.AddComponent<T>();
            }
            return child.GetComponent<T>();
        }
        return null;
    }
}
