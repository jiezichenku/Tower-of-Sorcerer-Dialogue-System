using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

public class Enemy : OnHitEvent
{
    public int enemyID;
    public EnemyAttribute attribute { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        LoadEnemyData();
    }

    public override void onHitEvent()
    {
        if (battle())
        {
            remove();
        }
        
    }
    public bool battle()
    {
        BraverStatus braverStatus = BraverStatus.GetInstance();
        int braverHealth = braverStatus.getAttributes().GetAttribute("Health");
        int damage = EnemyProperty.DamageCalculate(attribute);
        if (braverHealth > damage && damage >= 0)
        {
            braverStatus.UpdateStatus("Health", -1 * damage);
            braverStatus.UpdateStatus("Gold", attribute.Gold);
            braverStatus.UpdateStatus("Experience", attribute.Experience);
            return true;
        }
        return false;
    }

    private void LoadEnemyData()
    {
        if (GlobalVariables.enemyAttributeTempStore.ContainsKey(enemyID))
        {
            GlobalVariables.enemyAttributeTempStore.TryGetValue(enemyID, out EnemyAttribute at);
            attribute = at;
        }
        else
        {
            attribute = Model.GetEnemyData(enemyID);
            GlobalVariables.enemyAttributeTempStore.Add(enemyID, attribute);
        }
    }
}
