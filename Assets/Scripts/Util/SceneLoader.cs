using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    void Start()
    {
        onSceneLoad();
    }
    public void onSceneLoad()
    {
        // Move braver to current scene
        string sceneName = SceneManager.GetActiveScene().name;
        if (GlobalVariables.isTransfering && sceneName == GlobalVariables.targetSceneName)
        {
            SceneManager.MoveGameObjectToScene(GlobalVariables.braver, SceneManager.GetSceneByName(GlobalVariables.targetSceneName));
            GlobalVariables.braver.transform.position = GlobalVariables.targetPosition;
            SceneManager.MoveGameObjectToScene(GlobalVariables.UI, SceneManager.GetSceneByName(GlobalVariables.targetSceneName));
            GlobalVariables.UI.transform.position = new Vector2(-3, 0);
            GlobalVariables.isTransfering = false;
        }
        // Delete destroyed objects
        if (GlobalVariables.sceneDestroyedObjects.ContainsKey(sceneName))
        {
            //if scene was loaded
            GlobalVariables.sceneDestroyedObjects.TryGetValue(sceneName, out List<Vector2> destroyedList);
            GameObject obstacle = GameObject.Find("Obstacle");
            //search those game objects located on destroyed lists
            foreach (Transform children in obstacle.transform.GetComponentInChildren<Transform>())
            {
                foreach (Transform child in children.GetComponentInChildren<Transform>())
                {
                    Vector2 position = new Vector2(child.position.x, child.position.y);
                    if (destroyedList.Contains(position))
                    {
                        Destroy(child.gameObject);
                    }
                }
            }
        }
        else
        {
            //if not loaded then initialize
            GlobalVariables.sceneDestroyedObjects.Add(sceneName, new List<Vector2>());
        }
        // Update status
        int floor = int.Parse(sceneName.Replace("Floor", ""));
        BraverStatus status = BraverStatus.GetInstance();
        status.SetStatus("Floor", floor);
    }

    public void loadTargetScene(string targetSceneName, Vector2 targetPosition)
    {
        //Get current floor
        string currentSceneName = SceneManager.GetActiveScene().name;
        //Move braver to new floor
        try
        {
            if (GlobalVariables.braver == null)
            {
                string braverPerfab = "Prefab/Braver";
                GameObject braver = GameObject.Instantiate(Resources.Load<GameObject>(braverPerfab));
                braver.name = "Braver";
                GlobalVariables.braver = braver;
            }

            if (GlobalVariables.UI == null)
            {
                string UIPerfab = "Prefab/UI/UI";
                GameObject UI = GameObject.Instantiate(Resources.Load<GameObject>(UIPerfab));
                UI.name = "UI";
                GlobalVariables.UI = UI;
            }
            DontDestroyOnLoad(GlobalVariables.UI);
            DontDestroyOnLoad(GlobalVariables.braver);
            //Transfer braver
            GlobalVariables.isTransfering = true;
            GlobalVariables.targetSceneName = targetSceneName;
            GlobalVariables.targetPosition = targetPosition;
            //Load new scene
            SceneManager.LoadScene(targetSceneName);
        }
        catch (UnityException e)
        {
            Debug.LogError(e);
        }
    }
}
