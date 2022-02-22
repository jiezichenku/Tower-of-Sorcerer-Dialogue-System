using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemDataConstructor
{
    public List<Item> items;
    GameObject itemDataPanel;
    public ItemDataConstructor(string fatherPath)
    {
        // Check if item data panel already has content
        itemDataPanel = GameObject.Find(fatherPath + "/ItemDataPanel");
        if (itemDataPanel.transform.childCount != 1)
        {
            return;
        }
        // Get items 
        Repository repository = Repository.GetInstance();
        List<int> itemIDList = repository.getItemList();

        //// One page contains 6 enemy display, if enemy display more than 6, make a scroll view
        int displayCount = itemIDList.Count;

        //// Create new scroll view
        int currentIndex = 0;

        if (displayCount > 6)
        {
            string scrollPath = "Prefab/UI/Scroll";
            GameObject scroll = GameObject.Instantiate(Resources.Load<GameObject>(scrollPath), itemDataPanel.transform);
            GameObject content = scroll.transform.Find("Viewport/Content").gameObject;
            RectTransform contentTransform = content.transform.GetComponent<RectTransform>();
            contentTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 2 * displayCount);
            foreach (int itemID in itemIDList)
            {
                int itemNum = repository.getItemNum(itemID);
                string itemName = repository.getItemName(itemID);
                DisplayEnemyData(currentIndex, itemName, itemNum, content);
                currentIndex++;
            }
        }
        else
        {
            foreach (int itemID in itemIDList)
            {
                int itemNum = repository.getItemNum(itemID);
                string itemName = repository.getItemName(itemID);
                DisplayEnemyData(currentIndex, itemName, itemNum, itemDataPanel);
                currentIndex++;
            }
        }
    }

    void DisplayEnemyData(int currentIndex, string itemName, int itemNum, GameObject parent)
    {
        GameObject dispaly = GameObject.Instantiate(Resources.Load<GameObject>("Prefab/UI/ItemData/ItemDataDisplay"), parent.transform);
        RectTransform transform = dispaly.transform.GetComponent<RectTransform>();
        transform.anchoredPosition = new Vector2(0, -1 * currentIndex - 1);
        // Set item icon 
        string path = $"Graphics/Item/{itemName}";
        GameObject icon = dispaly.transform.Find("Icon").gameObject;
        icon.GetComponent<Image>().sprite = Resources.Load<Sprite>(path);

        // Set item name
        GameObject name = dispaly.transform.Find("Name").gameObject;
        name.GetComponent<TMP_Text>().text = itemName;

        //Set enemy attributes
        GameObject num = dispaly.transform.Find("Num").gameObject;
        num.GetComponent<TMP_Text>().text = $"x{itemNum}";
    }
}
