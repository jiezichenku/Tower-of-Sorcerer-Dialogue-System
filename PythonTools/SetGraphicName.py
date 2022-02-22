import os

filePath = os.path.abspath(os.path.pardir) + "\\Assets\\Resources\\Graphics"
os.chdir(filePath)
folderList = os.listdir(filePath)
for folder in folderList:
    if folder == "Animations":
        folderPath = os.getcwd() + "\\" + folder
        os.chdir(folderPath)
        graphicList = os.listdir(folderPath)
        for graphic in graphicList:
            newName = graphic[16:]
            print(newName)
            os.rename(graphic, newName)
    os.chdir(filePath)