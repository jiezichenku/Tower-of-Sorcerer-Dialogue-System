import math
import os

scenePath = "E:/Tower of Sorcerer/Assets/Scenes"
os.chdir(scenePath)
sceneName = "Floor001.unity"
with open(sceneName, "r") as f:
    lines = f.readlines()
    tag = False
    for i in range(len(lines)):
        if tag:
            tmp = lines[i].replace(" ", "")
            text = tmp.replace("\n", "")
            value = text.replace("value:", "")
            val = float(value)
            decimal = math.modf(val)[0]
            integer = int(val)
            fixedInt = integer
            if abs(decimal) > 0.5:
                if val < 0:
                    fixedInt -= 1
                else:
                    fixedInt += 1
            lines[i] = "      value: "+str(fixedInt)+"\n"
            tag = False
        if not tag:
            tmp = lines[i].replace(" ", "")
            text = tmp.replace("\n", "")
            if text == "propertyPath:m_LocalPosition.x" or text == "propertyPath:m_LocalPosition.y":
                tag = True
print(lines)
with open(sceneName, "w") as f:
    f.writelines(lines)