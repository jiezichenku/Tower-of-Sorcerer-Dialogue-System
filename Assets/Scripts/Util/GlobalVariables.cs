using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables
{
    // Ignore keyboard input
    public static bool Pause = false;
    // Pointer to braver object
    public static GameObject braver;
    // Pointer to UI canvas
    public static GameObject UI;

    // Get current event name
    public static string currentEventName;

    // Game map lists
    public static List<Map> maps = new List<Map>();

    // Braver transfer
    public static bool isTransfering;
    public static string targetSceneName;
    public static Vector2 targetPosition;

    // Scene destroyed objects
    public static Dictionary<string, List<Vector2>> sceneDestroyedObjects = new Dictionary<string, List<Vector2>>();

    // Store enemy data
    public static Dictionary<int, EnemyAttribute> enemyAttributeTempStore = new Dictionary<int, EnemyAttribute>();

    // Store item information
    public static ItemAttribute itemAttributeTempStore = new ItemAttribute();

    // Save data
    public static SaveData saveData;
}
