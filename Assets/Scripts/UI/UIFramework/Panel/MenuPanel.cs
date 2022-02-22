using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuPanel : BasePanel
{
    static readonly string path = "Prefab/UI/MenuPanel";
    public MenuPanel() : base(new UIType(path))
    {

    }

    public override void OnEnter()
    {
        EnemyDataConstructor constructor = new EnemyDataConstructor("UI/MenuPanel");
        EventSystem eventSystem = EventSystem.current;
        eventSystem.SetSelectedGameObject(GameObject.Find("EnemyDataButton"));
        //Debug.Log(eventSystem.SelectedGameObject);
        tool.GetOrAddComponentInChildren<Button>("EnemyDataButton").onClick.AddListener(() =>
        {
            manager.Push(new EnemyDataPanel());
        });
        tool.GetOrAddComponentInChildren<Button>("ItemButton").onClick.AddListener(() =>
        {
            manager.Push(new ItemDataPanel());
        });
        tool.GetOrAddComponentInChildren<Button>("LoadButton").onClick.AddListener(() =>
        {
            //manager.Push(new LoadPanel());
        });
    }

    public override void OnExit()
    {

    }
}
