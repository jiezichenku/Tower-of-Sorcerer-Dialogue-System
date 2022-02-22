using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEditor.Animations;

public class EnemyAnimationGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        getAnimationController();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static void getAnimationController()
    {
        string enemyPrefabFolder = "Assets/Resources/Prefab/Enemy";
        string controllerFolder = "Assets/Animation/Enemy";
        foreach (var enemyPrefabFile in Directory.GetFiles(enemyPrefabFolder))
        {
            if (enemyPrefabFile.Contains(".meta")) continue;
            GameObject enemyPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(enemyPrefabFile, typeof(GameObject));
            string enemyID = enemyPrefab.name;
            string controllerPath = $@"{controllerFolder}/{enemyID}/{enemyID}.controller";
            AnimatorController controller = (AnimatorController)AssetDatabase.LoadAssetAtPath(controllerPath, typeof(AnimatorController));
            enemyPrefab.GetComponent<Animator>().runtimeAnimatorController = controller;
            PrefabUtility.SavePrefabAsset(enemyPrefab);
        }
    }

    /// <summary>
    /// 菜单方法，遍历文件夹创建Animation Controller
    /// </summary>
    [MenuItem("Tools/CreateAnimator")]
    static void CreateAnimationAssets()
    {
        string rootFolder = "Assets/Animation/Enemy";
        if (!Directory.Exists(rootFolder))
        {
            Directory.CreateDirectory(rootFolder);
            return;
        }
        // 遍历目录，查找生成controller文件
        var folders = Directory.GetDirectories(rootFolder);
        foreach (var folder in folders)
        {
            DirectoryInfo info = new DirectoryInfo(folder);
            string folderName = info.Name;
            // 创建animationController文件
            bool tag = false;
            if (!tag)
            {
                AnimatorController.CreateAnimatorControllerAtPath($@"{folder}/{folderName}.controller");
            }
            
        }

    }
}
