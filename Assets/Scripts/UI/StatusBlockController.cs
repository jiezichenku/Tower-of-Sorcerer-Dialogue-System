using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusBlockController : MonoBehaviour
{
    //singleton
    BraverStatus status;
    Repository repository;
    //Dictionary of braver status
    BraverAttribute attribute;
    //List of display items 
    List<string> items;
    List<int> itemID;
    List<TextMesh> attributeText;
    void Start()
    {
        status = BraverStatus.GetInstance();
        repository = Repository.GetInstance();
        items = new List<string>();
        itemID = new List<int>();
        //Set the item information to display
        items.Add("YellowKey");
        itemID.Add(1);
        items.Add("BlueKey");
        itemID.Add(2);
        items.Add("RedKey");
        itemID.Add(3);
        //if (!EventCenter.Check(EventType.ItemUpdate))
        {
            //Set event listener
            EventCenter.AddListener(EventType.ItemUpdate, onUpdate);
            Debug.Log("itemListener");
        }
        //if (!EventCenter.Check(EventType.StatusUpdate))
        {
            EventCenter.AddListener(EventType.StatusUpdate, onUpdate);
            Debug.Log("stateListener");
        }
        
        //update the value
        onUpdate();
    }
    public void onUpdate()
    {
        attribute = status.getAttributes();
        string[] attributes = {"Floor", "Health", "Attack", "Defence", "Shield", "Gold", "Experience" };
        foreach (string a in attributes)
        {
            string avalue = a + "Value";
            GameObject ob = GameObject.Find(avalue);
            int value = attribute.GetAttribute(a);
            TextMeshProUGUI text = ob.GetComponent<TextMeshProUGUI>();
            text.SetText(value.ToString());
        }
        for (int i = 0; i < items.Count; i++)
        {
            string textName = items[i] + "Value";
            GameObject ob = GameObject.Find(textName);
            TextMeshProUGUI text = ob.GetComponent<TextMeshProUGUI>();
            int num = repository.getItemNum(itemID[i]);
            if (num < 0)
            {
                num = 0;
            }
            text.SetText(num.ToString());
        }
        Debug.Log("End of update");
    }
}
