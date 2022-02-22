using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyDataConstructor
{
    List<GameObject> enemies = new List<GameObject>();
    GameObject enemyDataPanel;
    public EnemyDataConstructor(string fatherPath)
    {
        // Check if enemy data panel already has content
        enemyDataPanel = GameObject.Find(fatherPath + "/EnemyDataPanel");
        if (enemyDataPanel.transform.childCount != 1)
        {
            return;
        }
        // Get enemies in the floor
        GameObject enemy = GameObject.Find("Grid/Obstacle/Enemy");
        foreach (Transform e in enemy.transform)
        {
            enemies.Add(e.gameObject);
        }

        Dictionary<int, List<int>> damageDictionary = new Dictionary<int, List<int>>();
        // Reduce redundant enemy objects
        Dictionary<GameObject, int> enemiesToDisplay = new Dictionary<GameObject, int>();
        foreach (GameObject e in enemies)
        {
            int enemyID = e.GetComponent<Enemy>().enemyID;
            int damage = EnemyProperty.DamageCalculate(e.GetComponent<Enemy>().attribute);
            // Check and discard redundant enemy data
            if (damageDictionary.ContainsKey(enemyID))
            {
                // Check if the same damage of the enemy has displayed
                damageDictionary.TryGetValue(enemyID, out List<int> damageList);
                if (!damageList.Contains(damage))
                {
                    enemiesToDisplay.Add(e, damage);
                    damageList.Add(damage);
                    damageDictionary[enemyID] = damageList;
                }
            }
            else
            {
                enemiesToDisplay.Add(e, damage);
                // If enemy is first recorded, display and create record in dictionary
                List<int> damageList = new List<int>();
                damageList.Add(damage);
                damageDictionary.Add(enemyID, damageList);
            }
        }

        // One page contains 6 enemy display, if enemy display more than 6, make a scroll view
        int displayCount = enemiesToDisplay.Count;

        // Create new scroll view
        int currentIndex = 0;
        
        if (displayCount > 6)
        {
            string scrollPath = "Prefab/UI/Scroll";
            GameObject scroll = GameObject.Instantiate(Resources.Load<GameObject>(scrollPath), enemyDataPanel.transform);
            GameObject content = scroll.transform.Find("Viewport/Content").gameObject;
            RectTransform contentTransform = content.transform.GetComponent<RectTransform>();
            contentTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 2 * displayCount);
            foreach (var pair in enemiesToDisplay)
            {
                GameObject e = pair.Key;
                int damage = pair.Value;
                DisplayEnemyData(currentIndex, e, damage, content);
                currentIndex++;
            }

        }
        else
        {
            foreach (var pair in enemiesToDisplay)
            {
                GameObject e = pair.Key;
                int damage = pair.Value;
                DisplayEnemyData(currentIndex, e, damage, enemyDataPanel);
                currentIndex++;
            }
        }
        


    }

    void DisplayEnemyData(int currentIndex, GameObject e, int damage, GameObject parent)
    {
        GameObject dispaly = GameObject.Instantiate(Resources.Load<GameObject>("Prefab/UI/EnemyData/EnemyDataDisplay"), parent.transform);
        RectTransform transform = dispaly.transform.GetComponent<RectTransform>();
        transform.anchoredPosition = new Vector2(0, - 2 * currentIndex);
        // Get enemy information
        Enemy enemy = e.GetComponent<Enemy>();
        int enemyID = enemy.enemyID;
        string enemyName = enemy.attribute.EnemyName;

        // Set enemy icon 
        string path = $"Graphics/Enemy/Enemy{enemyID:D4}/1";
        GameObject icon = dispaly.transform.Find("Icon").gameObject;
        icon.GetComponent<Image>().sprite = Resources.Load<Sprite>(path);
        
        // Set enemy name
        GameObject name = dispaly.transform.Find("Name").gameObject;
        name.GetComponent<TMP_Text>().text = enemyName;

        // Set enemy skill
        string skillText = "Normal";
        if (enemy.attribute.Skill.Count == 1)
        {
            skillText = enemy.attribute.Skill[0];
        }
        if (enemy.attribute.Skill.Count > 1)
        {
            skillText = "Detail..";
        }
        GameObject skill = dispaly.transform.Find("Skill").gameObject;
        skill.GetComponent<TMP_Text>().text = skillText;

        //Set enemy attributes
        GameObject hp = dispaly.transform.Find("HP").gameObject;
        hp.GetComponent<TMP_Text>().text = $"HP: {enemy.attribute.Health}";
        GameObject atk = dispaly.transform.Find("ATK").gameObject;
        atk.GetComponent<TMP_Text>().text = $"ATK: {enemy.attribute.Attack}";
        GameObject def = dispaly.transform.Find("DEF").gameObject;
        def.GetComponent<TMP_Text>().text = $"DEF: {enemy.attribute.Defence}";
        GameObject gold = dispaly.transform.Find("GOLD").gameObject;
        gold.GetComponent<TMP_Text>().text = $"GOLD: {enemy.attribute.Gold}";
        GameObject exp = dispaly.transform.Find("EXP").gameObject;
        exp.GetComponent<TMP_Text>().text = $"EXP: {enemy.attribute.Experience}";
        GameObject dmg = dispaly.transform.Find("DMG").gameObject;
        
        if (damage == -1)
        {
            dmg.GetComponent<TMP_Text>().text = $"DMG: ???";
        }
        else
        {
            dmg.GetComponent<TMP_Text>().text = $"DMG: {damage}";
        }
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
