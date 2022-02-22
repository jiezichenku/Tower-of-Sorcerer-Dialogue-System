import json

with open("dialogueDatabaseTemp.json", 'r', encoding='utf-8') as f:
    data = json.load(f)
    f.close()

actorID = 0
for actor in data["actors"]:
    actorID += 1
    actor["id"] = actorID

for conversation in data["conversations"]:
    conversationID = conversation["id"]
    dialogueEntries = conversation["dialogueEntries"]
    id = 0
    for entry in dialogueEntries:
        entry["conversationID"] = conversationID
        entry["id"] = id
        id += 1
    id += 1

for conversation in data["conversations"]:
    conversationID = conversation["id"]
    dialogueEntries = conversation["dialogueEntries"]
    size = len(dialogueEntries)
    for entry in dialogueEntries:
        id = entry["id"]
        if len(entry["outgoingLinks"]) > 0:
            link = entry["outgoingLinks"][0]
            link["destinationConversationID"] = conversationID
            link["originConversationID"] = conversationID
            link["destinationDialogueID"] = id + 1
            link["originDialogueID"] = id

with open("dialogueDatabaseTemp.json", 'w', encoding='utf-8') as f:
    json.dump(data, f, ensure_ascii=False, sort_keys=True, indent=4)
    f.close()
