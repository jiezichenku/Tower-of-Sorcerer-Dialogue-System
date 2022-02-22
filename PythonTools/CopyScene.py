import math
import os
import shutil

scenePath = "E:/Tower of Sorcerer/Assets/Resources/Data/EnemyData"
os.chdir(scenePath)
TemplateSceneName = "Enemy0031.prefab"
for i in range(2, 87):
    sceneName = "Enemy{:0>4d}.json".format(i)
    newName = "Enemy{:0>4d}.json".format(i-1)
    oldname = os.path.join(scenePath, sceneName)
    newname = os.path.join(scenePath, newName)
    os.rename(oldname, newname)

