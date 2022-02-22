import copy
import os
import json

mapFolder = "D:/xp2json/json"
ignoreList = [2, 3, 4, 5, 6, 8, 20, 43]
dialogueList = []
actorList = {"旁白": 0}
with open("dialogueDatabase.json", 'r', encoding='utf-8') as f:
    dialogueDatabase = json.load(f)
    f.close()

# 获取人物列表
actors = dialogueDatabase["actors"]
for i in range(0, len(dialogueDatabase["actors"])):
    if dialogueDatabase["actors"][i]["fields"][0]["title"] == "Name":
        actorList[dialogueDatabase["actors"][i]["fields"][0]["value"]] = i + 1

# 获取对话
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
                    # 获取对话属性
                    text = operation["parameters"][0]
                    name = ""
                    content = ""
                    if text.find('[') != -1 and text.find(']') != -1:
                        name = text[text.find('[') + 1: text.find(']')]
                        content = text[text.find(']') + 1:]
                    else:
                        name = "旁白"
                        content = text
                    if len(dialogueList) == 0 or event != dialogueList[len(dialogueList) - 1]["event"]:
                        dialogue = {"map": i, "event": event, "text": [{"name": name, "content": [content]}]}
                        dialogueList.append(dialogue)
                    else:
                        lastText = dialogueList[len(dialogueList) - 1]["text"]
                        if name != lastText[len(lastText) - 1]["name"]:
                            lastText.append({"name": name, "content": [content]})
                        else:
                            lastContent = lastText[len(lastText) - 1]["content"]
                            lastContent.append(content)
                if operation["code"] == 401:
                    lastText = dialogueList[len(dialogueList) - 1]["text"]
                    lastContent = lastText[len(lastText) - 1]["content"]
                    tmp = lastContent[len(lastContent) - 1]
                    lastContent[len(lastContent) - 1] = tmp + operation["parameters"][0]
# 解析DialogueDatabase文本
conversations = dialogueDatabase["conversations"]
newConversations = []
newConversations.append(conversations[0])
id = 0
for dialogue in dialogueList:
    id += 1
    # 标题
    title = "Map{:0>3d}Event{:0>3d}".format(int(dialogue["map"]), int(dialogue["event"]))
    # 参与者
    conversants = []
    for conversant in dialogue["text"]:
        if conversant["name"] not in actorList.keys():
            continue
        conversantID = actorList[conversant["name"]]
        if conversantID not in conversants:
            conversants.append(conversantID)
    # 设置标题与参与者
    conversation = copy.deepcopy(conversations[1])
    tempConversant = {}
    for field in conversation["fields"]:
        if field["title"] == "Title":
            field["value"] = title
        if field["title"] == "Actor":
            field["value"] = conversants[0]
        if field["title"] == "Conversant":
            tempConversant = copy.deepcopy(field)
            if len(conversants) < 2:
                field["value"] = 2
            else:
                field["value"] = conversants[1]
    if len(conversants) == 3:
        tempConversant["value"] = conversants[2]
        conversation["fields"].append(tempConversant)
    if len(conversants) == 4:
        tempConversant2 = copy.deepcopy(tempConversant)
        tempConversant["value"] = conversants[2]
        conversation["fields"].append(tempConversant)
        tempConversant2["value"] = conversants[2]
        conversation["fields"].append(tempConversant2)

    # 设置文本
    dialogueEntries = conversation["dialogueEntries"]
    dialogueEntryCopy = copy.deepcopy(dialogueEntries)
    dialogueEntryFieldCopy = copy.deepcopy(dialogueEntries[1])
    tempDialogueEntries = [dialogueEntryCopy[0]]
    for texts in dialogue["text"]:
        actor = actorList[texts["name"]]
        for content in texts["content"]:
            tempDialogueEntryField = copy.deepcopy(dialogueEntryFieldCopy)
            for field in tempDialogueEntryField["fields"]:
                if field["title"] == "Actor":
                    field["value"] = actor
                if field["title"] == "Dialogue Text":
                    field["value"] = content
            tempDialogueEntries.append(tempDialogueEntryField)
    conversation["dialogueEntries"] = tempDialogueEntries
    newConversations.append(conversation)

dialogueDatabase["conversations"] = newConversations

with open("dialogueDatabaseTemp.json", 'w', encoding='utf-8') as f:
    json.dump(dialogueDatabase, f, ensure_ascii=False, sort_keys=True, indent=4)
    f.close()
