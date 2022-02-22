
import os
import json

mapFolder = "D:/xp2json/json"
ignoreList = [2, 3, 4, 5, 6, 20, 43]
actorList = []

with open("dialogueDatabase.json", 'r', encoding='gbk') as f:
    dialogueDatabase = json.load(f)
    f.close()

for i in range(1, 77):
    if i in ignoreList:
        continue
    mapFile = "Map{:0>3d}.json".format(i)
    with open(os.path.join(mapFolder, mapFile), 'r', encoding='gbk') as f:
        mapData = json.load(f)
        f.close()

    for event in mapData["events"]:
        for page in mapData["events"][event]["pages"]:
            for operation in page["list"]:
                if operation["code"] == 101:
                    text = operation["parameters"][0]
                    if text.find('[') != -1 and text.find(']') != -1:
                        name = text[text.find('[')+1: text.find(']')]
                        if name not in actorList and name[0:1] != '\\':
                            actorList.append(name)

actors = dialogueDatabase["actors"]
for i in range(2, len(actorList)):
    if actors[i]["fields"][0]["title"] == "Name":
        actors[i]["fields"][0]["value"] = actorList[i]

dialogueDatabase["actors"] = actors
with open("dialogueDatabase.json", 'w', encoding='utf-8') as f:
    json.dump(dialogueDatabase, f, ensure_ascii=False, sort_keys=True, indent=4)
    f.close()
