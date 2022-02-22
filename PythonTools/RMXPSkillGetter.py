
import os
import json

enemyFile = "D:/xp2json/json/Enemies.json"
skillFile = "D:/xp2json/json/Skills.json"
targetFolder = "E:/Tower of Sorcerer/enemy"

with open(skillFile, 'r', encoding='gbk') as f:
    skillList = json.load(f)
    f.close()

with open("1", "w", encoding='gbk') as f:
    for skill in skillList:
        if skill is None:
            continue
        skillName = skill["name"].split(":")[0]
        skillDescription = skill["description"]
        f.write(skillName)
        f.write(": ")
        f.write(skillDescription)
        f.write("\n")

