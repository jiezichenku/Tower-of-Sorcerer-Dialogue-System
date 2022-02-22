using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gateway : MonoBehaviour
{
    public string targetSceneName;
    public Vector2 targetPosition;
    private Map currentMap;
    private void Awake()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        Vector2 currentPosition = transform.position;
        string mapName = Regex.Replace(currentSceneName, @"-?\d", "");
        currentMap = Map.MapInstance(mapName);
        currentMap.AddGateway(currentSceneName, currentPosition, targetSceneName, targetPosition);
    }
    public void onHitEvent()
    {
        GameObject mainCamera = Camera.main.gameObject;
        SceneLoader loader = mainCamera.GetComponent<SceneLoader>();
        //Get current floor
        loader.loadTargetScene(targetSceneName, targetPosition);
    }
}
