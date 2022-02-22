using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class StoreConstructor
{

    public StoreConstructor(string money, List<StoreGoodJson> goods)
    {
        SetStoreGoods(money, goods);
    }

    private void SetStoreGoods(string money, List<StoreGoodJson> goods)
    {
        GameObject title = GameObject.Find("Title");
        string m;
        if (money == "Gold")
        {
            m = "G";
            title.GetComponent<TMP_Text>().text = "Gold Store";
        }
        else
        {
            m = "Exp";
            title.GetComponent<TMP_Text>().text = "Experience Store";
        }
        for (int i = 0; i < 4; i++)
        {
            GameObject button = GameObject.Find($@"Button{i}");
            if (i == 3)
            {
                button.GetComponentInChildren<TMP_Text>().text = "Exit";
            }
            else
            {
                StoreGoodJson good = goods[i];
                string txt = $@"{good.Good} +{good.Value}: {good.Price}{m}";
                button.GetComponentInChildren<TMP_Text>().text = txt;
            }
        }
    }
}
