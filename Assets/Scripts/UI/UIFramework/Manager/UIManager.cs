using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manage UI information and create or destroy UI
public class UIManager
{
    //Store UI information and its correspond game object
    private Dictionary<string, GameObject> UIInfo;
    private static UIManager singleInstance;
    public static UIManager GetInstance()
    {
        if (singleInstance == null)
        {
            singleInstance = new UIManager();
        }
        return singleInstance;
    }
    private UIManager()
    {
        UIInfo = new Dictionary<string, GameObject>();
    }

    public GameObject GetSingleUI(UIType type)
    {
        // Set UI in Canvas
        GameObject parent = GameObject.Find("UI");
        if (!parent)
        {
            Debug.LogError("No canvas to display UI");
            return null;
        }
        // Return UI if existed
        if (UIInfo.ContainsKey(type.Name))
        {
            return UIInfo[type.Name];
        }
        // Create new UI if not existed
        GameObject UI = GameObject.Instantiate(Resources.Load<GameObject>(type.Path), parent.transform);
        UI.name = type.Name;
        UIInfo.Add(type.Name, UI);
        return UI;
    }
    // Destroy UI
    public void DestroyUI(UIType type)
    {
        if (UIInfo.ContainsKey(type.Name))
        {
            GameObject.Destroy(UIInfo[type.Name]);
            UIInfo.Remove(type.Name);
        }
    }

    public bool HasUI(UIType type)
    {
        return UIInfo.ContainsKey(type.Name);
    }
}
