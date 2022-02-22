
import os
import json

enemyFile = "D:/xp2json/json/Enemies.json"
skillFile = "D:/xp2json/json/Skills.json"
targetFolder = "E:/Tower of Sorcerer/enemy"
with open(enemyFile, 'r', encoding='gbk') as f:
    data = json.load(f)
    f.close()

with open(skillFile, 'r', encoding='gbk') as f:
    skillList = json.load(f)
    f.close()

a = ["EnemyID",
              "EnemyName",
              "Health",
              "Attack",
              "Defence",
              "Gold",
              "Experience",
              "Skill"]

for i in range(37, 123):
    fileName = "Enemy{:0>4d}.json".format(i-36)
    eid = i
    name = data[i]["name"]
    atk = data[i]["atk"]
    maxhp = data[i]["maxhp"]
    pdef = data[i]["pdef"]
    gold = data[i]["gold"]
    exp = data[i]["exp"]
    skills = []
    for j in range(1, len(data[i]["element_ranks"]["data"])):
        if data[i]["element_ranks"]["data"][j] < 3:
            skillName = skillList[j]["name"]
            skills.append(skillName)
            print(skillName)
    JsonText = {a[0]: eid,
                a[1]: name,
                a[2]: maxhp,
                a[3]: atk,
                a[4]: pdef,
                a[5]: gold,
                a[6]: exp,
                a[7]: skills}
    with open(fileName, 'w') as fi:
        json.dump(JsonText, fi, ensure_ascii=False, sort_keys=True, indent=4)

