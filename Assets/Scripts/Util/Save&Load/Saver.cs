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
        // ��ȡ��ǰ��ʿ״̬
        Vector2 position = GlobalVariables.braver.transform.position;
        BraverAttribute attribute = BraverStatus.GetInstance().getAttributes();
        // ��ȡ��Ʒ��
        List<int> items = Repository.GetInstance().getItemList();
        // ��ȡ��ǰ¥�����Ѵݻ��¼�
        string currentSceneName = SceneManager.GetActiveScene().name;
        Dictionary<string, List<Vector2>> sceneDestroyedObjects = new Dictionary<string, List<Vector2>>();
        // ��ȡ�����¼�
        Dictionary<EventType, Delegate> eventTable = EventCenter.eventTable;
        // ����saveData
        saveData = new SaveData(currentSceneName, position, attribute, items, sceneDestroyedObjects, eventTable);
    }

    public static void load()
    {
        // ��ȡ�Ѵݻ���Ʒ
        GlobalVariables.sceneDestroyedObjects = saveData.getDestroyedObjects();

        // ��ȡ������λ��
        string targetSceneName = saveData.getCurrentSceneName();
        Vector2 targetPosition = saveData.getBraverPosition();
        GameObject mainCamera = Camera.main.gameObject;
        SceneLoader loader = mainCamera.GetComponent<SceneLoader>();

        // ��ȡ������������Ʒ
        BraverStatus.GetInstance(saveData.getBraverAttribute());
        Repository.GetInstance(saveData.getItems());

        // ��ȡ�����¼�
        EventCenter.eventTable = saveData.getEventTable();
        loader.loadTargetScene(targetSceneName, targetPosition);
    }
}
