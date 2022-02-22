import os

Path = "C:\\Users\\a'su's\\Tower of Sorcerer\\Assets\\Animation\\Enemy"
os.chdir(Path)
for i in range(19, 43):
    name = "Enemy00" + str(i)
    os.chdir(Path)
    folderName = Path + "\\" + name
    os.makedirs(folderName)
