using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataPanel : BasePanel
{
    static readonly string path = "Prefab/UI/EnemyData/EnemyDataPanel";
    public EnemyDataPanel() : base(new UIType(path))
    {

    }

    public override void OnEnter()
    {
        EnemyDataConstructor constructor = new EnemyDataConstructor("UI");

    }

    public override void OnExit()
    {
        
    }
}
