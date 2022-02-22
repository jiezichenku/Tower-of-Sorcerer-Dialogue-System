using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Saver
{
    static SaveData saveData;

    public static void save()
    {
        // 获取当前勇士状态
        Vector2 position = GlobalVariables.braver.transform.position;
        BraverAttribute attribute = BraverStatus.GetInstance().getAttributes();
        // 获取物品栏
        List<int> items = Repository.GetInstance().getItemList();
        // 获取当前楼层与已摧毁事件
        string currentSceneName = SceneManager.GetActiveScene().name;
        Dictionary<string, List<Vector2>> sceneDestroyedObjects = new Dictionary<string, List<Vector2>>();
        // 获取监听事件
        Dictionary<EventType, Delegate> eventTable = EventCenter.eventTable;
        // 生成saveData
        saveData = new SaveData(currentSceneName, position, attribute, items, sceneDestroyedObjects, eventTable);
    }

    public static void load()
    {
        // 读取已摧毁物品
        GlobalVariables.sceneDestroyedObjects = saveData.getDestroyedObjects();

        // 读取场景与位置
        string targetSceneName = saveData.getCurrentSceneName();
        Vector2 targetPosition = saveData.getBraverPosition();
        GameObject mainCamera = Camera.main.gameObject;
        SceneLoader loader = mainCamera.GetComponent<SceneLoader>();

        // 读取勇者属性与物品
        BraverStatus.GetInstance(saveData.getBraverAttribute());
        Repository.GetInstance(saveData.getItems());

        // 读取监听事件
        EventCenter.eventTable = saveData.getEventTable();
        loader.loadTargetScene(targetSceneName, targetPosition);
    }
}
