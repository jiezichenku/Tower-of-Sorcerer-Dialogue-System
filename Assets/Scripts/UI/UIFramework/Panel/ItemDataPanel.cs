using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDataPanel : BasePanel
{
    static readonly string path = "Prefab/UI/ItemData/ItemDataPanel";
    public ItemDataPanel() : base(new UIType(path))
    {
    }

    public override void OnEnter()
    {
        ItemDataConstructor constructor = new ItemDataConstructor("UI");
    }

    public override void OnExit()
    {

    }
}
