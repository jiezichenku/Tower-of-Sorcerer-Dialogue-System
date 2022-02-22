using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map
{
    public string mapName;
    List<MapVertex> Vertices;
    //Using singleton pattern by global variable
    public static Map MapInstance(string name)
    {
        foreach (Map m in GlobalVariables.maps)
        {
            if (m.mapName == name)
            {
                return m;
            }
        }
        return new Map(name);

    }
    private Map(string name)
    {
        mapName = name;
        Vertices = new List<MapVertex>();
    }
    public void AddGateway(string currentSceneName, Vector2 currentGatewayPosition, string targetSceneName, Vector2 targetPosition)
    {
        MapVertex currentScene = new MapVertex(currentSceneName);
        MapVertex targetScene = new MapVertex(targetSceneName);
        bool isCurrentSceneExist = false, isTargetSceneExist = false, isGatewayExist = false;
        //Check whether the scene exists in the map
        foreach (MapVertex v in Vertices)
        {
            if (v.scene == currentSceneName)
            {
                isCurrentSceneExist = true;
                currentScene = v;
            }
            if (v.scene == targetSceneName)
            {
                isTargetSceneExist = true;
                targetScene = v;
            }
        }
        //Load scene if does not exist
        if (!isCurrentSceneExist)
        {
            Vertices.Add(currentScene);
        }
        if (!isTargetSceneExist)
        {
            Vertices.Add(targetScene);
        }
        //Creat new edge
        foreach (MapGateway gateway in currentScene.gateways)
        {
            if (gateway.currentPosition == currentGatewayPosition)
            {
                isGatewayExist = true;
                break;
            }
        }
        if (!isGatewayExist)
        {
            MapGateway gateway = new MapGateway(currentGatewayPosition, targetSceneName, targetPosition);
        }
    }
    public string getTargetScnene(string currentSceneName, Vector2 currentGatewayPosition)
    {
        foreach (MapVertex v in Vertices)
        {
            if (v.scene == currentSceneName)
            {
                foreach (MapGateway g in v.gateways)
                {
                    if (g.currentPosition == currentGatewayPosition)
                    {
                        return g.targetScene;
                    }
                }
                throw new System.Exception("Invalid gateway");
            }
        }
        throw new System.Exception("Invalid scene");
    }
    public Vector2 getTargetPosition(string currentSceneName, Vector2 currentGatewayPosition)
    {
        foreach (MapVertex v in Vertices)
        {
            if (v.scene == currentSceneName)
            {
                foreach (MapGateway g in v.gateways)
                {
                    if (g.currentPosition == currentGatewayPosition)
                    {
                        return g.targetPosition;
                    }
                }
                throw new System.Exception("Invalid gateway");
            }
        }
        throw new System.Exception("Invalid scene");
    }
}

struct MapVertex
{
    public string scene;
    public List<MapGateway>gateways;
    public MapVertex(string sceneName)
    {
        scene = sceneName;
        gateways = new List<MapGateway>();
    }
};

struct MapGateway
{
    public Vector2 currentPosition;
    public string targetScene;
    public Vector2 targetPosition;
    public MapGateway(Vector2 cp, string ts, Vector2 tp)
    {
        currentPosition = cp;
        targetScene = ts;
        targetPosition = tp;
    }
}

