using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class Model
{
    private static string folderPath = @"Data\";
    public static BraverAttribute GetInitBraverData()
    {
        TextAsset initStatus = ReadJson("InitBraverStatus");
        return JsonUtility.FromJson<BraverAttribute>(initStatus.text);
    }

    public static EnemyAttribute GetEnemyData(int enemyID)
    {
        TextAsset enemyData = ReadJson($@"EnemyData\Enemy{enemyID:D4}");
        return JsonUtility.FromJson<EnemyAttribute>(enemyData.text);
    }

    public static ItemAttribute GetItemData()
    {
        TextAsset itemData = ReadJson($@"ItemData\ItemInfo");
        return JsonUtility.FromJson<ItemAttribute>(itemData.text);
    }

    public static StoreAttribute GetStoreData(int storeID)
    {
        TextAsset storeData = ReadJson($@"StoreData\Store{storeID:D4}");
        return JsonUtility.FromJson<StoreAttribute>(storeData.text);
    }
    private static TextAsset ReadJson(string fileName)
    {
        string jsonFile = folderPath + fileName;//JSONÎÄ¼þÂ·¾¶
        TextAsset file = Resources.Load<TextAsset>(jsonFile);
        return file;
    }
}

