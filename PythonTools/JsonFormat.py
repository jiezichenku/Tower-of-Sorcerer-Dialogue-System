import os
import json
#
filePath = "E:/Tower of Sorcerer/PythonTools"
os.chdir(filePath)
jsonList = os.listdir(filePath)
for jsonFile in jsonList:
    if jsonFile.find(".json") > 0:
        with open(jsonFile, 'r', encoding='utf-8-sig') as f:
            data = json.load(f)
            f.close()

        with open(jsonFile, 'w') as f:
            json.dump(data, f, ensure_ascii=False, sort_keys=True, indent=4)

