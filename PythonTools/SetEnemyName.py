import os
import json

graphicPath = "C:\\Users\\a'su's\\Tower of Sorcerer\\Assets\\Resources\\Graphics\\Enemy"
jsonPath = "C:\\Users\\a'su's\\Tower of Sorcerer\\Assets\\Scripts\\Model\\Data\\EnemyData"
jsonList = []
enemyInfo = {}
for file in os.listdir(jsonPath):
    if file.endswith(".json"):
        jsonList.append(file)

for jsonFile in jsonList:
    with open(jsonPath+"\\"+jsonFile, 'r', encoding='utf-8') as f:
        data = json.load(f)
        enemyID = data["EnemyID"]
        enemyName = data["EnemyName"].replace(" ", "")
        enemyInfo[enemyName] = enemyID

os.chdir(graphicPath)
print(os.listdir)
for file in os.listdir(graphicPath):
    if enemyInfo.keys().__contains__(file):
        fileName = "Enemy%04d" % enemyInfo[file]
        os.rename(file, fileName)
        os.chdir(fileName)
        for files in os.listdir(graphicPath+"\\"+fileName):
            if files.endswith("1.png"):
                os.rename(files, "1.png")
            elif files.endswith("2.png"):
                os.rename(files, "2.png")
        os.chdir(graphicPath)
        print(fileName)