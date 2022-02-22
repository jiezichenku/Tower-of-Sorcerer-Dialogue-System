import cv2
import numpy
import os

imgPath = "D:\\魔塔样板7630·改\\Graphics\\Characters"
os.chdir(imgPath)
img = cv2.imread("101-item01.png", cv2.IMREAD_UNCHANGED)
imgNames = ["GreenSlime", "RedSlime", "Bat", "Priest", "SkeletonC", "SkeletonB", "GateKeeperC", "SkeletonA"]
Path = "C:\\Users\\a'su's\\Tower of Sorcerer\\Assets\\Resources\\Graphics\\Item"
os.chdir(Path)
for i in range(4):
    imgName = imgNames[i]
    newName = "Enemy000"+str(i)
    tmpImg = img[32:64, 32*i:32*(i+1)]
    print(newName)
    cv2.imwrite("KeySet"+str(i)+".png", tmpImg)
    cv2.waitKey(0)
