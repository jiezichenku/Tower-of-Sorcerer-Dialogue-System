import os

filePath = os.path.pardir + "\\Assets\\Resources\\Graphics"
os.chdir(filePath)
target = []
print(os.getcwd())
for root, dirs, files in os.walk(os.getcwd()):
    for file in files:
        if file.find("png.meta") != -1:
            fileName = "%s\\%s"%(root, file)
            target.append(fileName)
            print(fileName)

for file in target:
    with open(file, "r+") as f:
        text = f.read()
        # content = text.replace("spritePixelsToUnits: 100", "spritePixelsToUnits: 32")
        content = text.replace("spriteMode: 1", "spriteMode: 2")
        f.seek(0)
        f.write(content)

