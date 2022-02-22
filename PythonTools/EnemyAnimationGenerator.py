import os
import shutil

animationPath = "E:/Tower of Sorcerer/Assets/Animation/Enemy"
prefabPath = "E:/Tower of Sorcerer/Assets/Resources/Prefab/Enemy"
spritePath = "E:/Tower of Sorcerer/Assets/Resources/Graphics/Characters"
prototypePath = os.path.join(animationPath, "Enemy0000")
animatorPrototype = os.path.join(prototypePath, "Enemy0000.controller")
clipPrototype = os.path.join(prototypePath, "Idle.anim")

# 行走图以及ID的哈希表
graphicMap = {}
os.chdir(spritePath)
for metaFile in os.listdir():
    if metaFile.find(".meta") != -1:
        with open(metaFile, "r") as f:
            text = f.read()
            guidStartIndex = text.find("guid: ") + len("guid: ")
            guidEndIndex = text[guidStartIndex:].find("\n") + guidStartIndex
            guid = text[guidStartIndex:guidEndIndex]
            graphicMap[guid] = metaFile
            f.close()
ignore = [18, 37, 56, 68]
for i in range(1, 86):
    if i in ignore:
        continue
    os.chdir(spritePath)
    # 获取Enemy对应行走图以及第一帧
    prefab = os.path.join(prefabPath, "Enemy{:0>4d}.prefab".format(i))
    spriteInfo = []
    with open(prefab, "r") as f:
        text = f.read()
        spriteIDStartIndex = text.find("m_Sprite: {fileID:") + len("m_Sprite: {fileID:")
        spriteIDEndIndex = text[spriteIDStartIndex:].find(",") + spriteIDStartIndex
        spriteID = text[spriteIDStartIndex:spriteIDEndIndex]
        guidStartIndex = text[spriteIDEndIndex:].find("  ,guid: ") + len("  ,guid: ") + spriteIDEndIndex
        graphicIDEndIndex = text[guidStartIndex:].find(",") + guidStartIndex
        graphicID = text[guidStartIndex:graphicIDEndIndex]
        spriteInfo.append(graphicID)
        spriteInfo.append(spriteID)
        f.close()

    # 获取Enemy对应行走图第三帧
    with open(graphicMap[spriteInfo[0]], "r") as f:
        text = f.read().split("externalObjects")[0]
        sprites = text.split("first")
        targetIndex = 0
        for spriteIndex in range(0, len(sprites)):
            if sprites[spriteIndex].find(spriteInfo[1]) != -1:
                targetIndex = spriteIndex + 2
        targetText = sprites[targetIndex]
        targetStartIndex = targetText.find("213: ") + len("213: ")
        targetEndIndex = targetText[targetStartIndex:].find("\n") + targetStartIndex
        targetSpriteID = targetText[targetStartIndex:targetEndIndex]
        spriteInfo.append(targetSpriteID)
        f.close()

    #新建动画文件夹并创建clip
    os.chdir(animationPath)
    clipPath = os.path.join(animationPath, "Enemy{:0>4d}".format(i))
    clip = os.path.join(clipPath, "Idle.anim")
    shutil.copy(clipPrototype, clip)
    with open(clip, "r") as f:
        text = f.read()
        frame1 = "fileID: 177202907793577026, guid: 86acfcd81fd0b5f4885fdb49f5aaea7c, type: 3"
        frame3 = "fileID: -687746235105842534, guid: 86acfcd81fd0b5f4885fdb49f5aaea7c, type: 3"
        tmp = text.replace(frame1, "fileID: {0}, guid: {1}, type: 3".format(spriteInfo[1], spriteInfo[0]))
        content = tmp.replace(frame3, "fileID: {0}, guid: {1}, type: 3".format(spriteInfo[2], spriteInfo[0]))
        print(i)
        f.close()

    with open(clip, "w") as f:
        f.write(content)
