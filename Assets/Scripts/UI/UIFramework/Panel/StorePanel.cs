using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorePanel : BasePanel
{

    static readonly string path = "Prefab/UI/Store/StorePanel";
    int storeID;
    string money;
    string storeType;
    public List<StoreGoodJson> goods;
    public StorePanel(int ID) : base(new UIType(path))
    {
        storeID = ID;
    }

    public override void OnEnter()
    {
        StoreAttribute attribute = Model.GetStoreData(storeID);
        storeType = attribute.Type;
        money = attribute.Money;
        goods = attribute.Goods;
        StoreConstructor constructor = new StoreConstructor(money, goods);
        tool.GetOrAddComponentInChildren<Button>($@"Button0").onClick.AddListener(() =>
        {
            Purchase(goods[0]);
        });
        tool.GetOrAddComponentInChildren<Button>($@"Button1").onClick.AddListener(() =>
        {
            Purchase(goods[1]);
        });
        tool.GetOrAddComponentInChildren<Button>($@"Button2").onClick.AddListener(() =>
        {
            Purchase(goods[2]);
        });
        tool.GetOrAddComponentInChildren<Button>("Button3").onClick.AddListener(() =>
        {
            manager.Pop();
        });
    }

    private void Purchase(StoreGoodJson storeGood)
    {
        BraverStatus status = BraverStatus.GetInstance();
        if (storeType == "Attribute")
        {
            int moneyHold = status.getAttributes().GetAttribute(money);
            if (moneyHold >= storeGood.Price)
            {
                status.UpdateStatus(storeGood.Good, storeGood.Value);
                status.UpdateStatus(money, storeGood.Price * -1);
            }
        }
        else if (storeType == "Item")
        {
            Repository repository = Repository.GetInstance();
            int itemID = int.Parse(storeGood.Good);
            int moneyHold = status.getAttributes().GetAttribute(money);
            if (moneyHold >= storeGood.Price)
            {
                repository.UpdateItem(itemID, storeGood.Value);
                status.UpdateStatus(money, storeGood.Price * -1);
            }
        }

    }
}
