using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    public string firstSceneName;
    public Vector2 firstPosition;
    void Start()
    {
        transferToScene();
    }
    void transferToScene()
    {
        string braverPerfab = "Prefab/Braver";
        string UIPerfab = "Prefab/UI/UI";
        GameObject braver = GameObject.Instantiate(Resources.Load<GameObject>(braverPerfab));
        braver.name = "Braver";
        GameObject UI = GameObject.Instantiate(Resources.Load<GameObject>(UIPerfab));
        UI.name = "UI";
        GlobalVariables.braver = braver;
        GlobalVariables.UI = UI;
        //Protect object
        DontDestroyOnLoad(GlobalVariables.braver);
        DontDestroyOnLoad(GlobalVariables.UI);
        //Transfer braver
        GlobalVariables.isTransfering = true;
        GlobalVariables.targetSceneName = firstSceneName;
        GlobalVariables.targetPosition = firstPosition;
        //Load new scene
        SceneManager.LoadScene(firstSceneName);
    }
}
