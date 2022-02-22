import os
import json

Data = "C:\\Users\\a'su's\\Tower of Sorcerer\\enemy.txt"
a = ["EnemyID",
              "EnemyName",
              "Health",
              "Attack",
              "Defence",
              "Gold",
              "Experience",
              "Skill"]
with open(Data, 'r', encoding='utf-8') as f:
    os.chdir("C:\\Users\\a'su's\\Tower of Sorcerer\\Assets\\Scripts\\Model\\Data\\EnemyData")
    enemies = f.readlines()
    for i in range(len(enemies)):
        e = enemies[i].replace("(", "")
        en = e.replace(")", "")
        ene = en.replace("\n", "")
        enem = ene.replace("\"", "")
        values = enem.split(", ")
        for j in range(5):
            values[j] = int(values[j])
        enemyID = i+1
        JsonText = {a[0]: enemyID,
                    a[1]: values[5],
                    a[2]: values[0],
                    a[3]: values[1],
                    a[4]: values[2],
                    a[5]: values[3],
                    a[6]: values[4],
                    a[7]: []}
        fileName = "Enemy%04d.json" % enemyID
        print(fileName)
        with open(fileName, 'w') as fi:
            json.dump(JsonText, fi, ensure_ascii=False, sort_keys=True, indent=4)
