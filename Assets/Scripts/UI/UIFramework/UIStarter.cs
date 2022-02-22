using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStarter : MonoBehaviour
{
    PanelManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = PanelManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.Peek() != null)
        {
            Time.timeScale = 0;
            GlobalVariables.Pause = true;
        }
        else
        {
            Time.timeScale = 1;
            GlobalVariables.Pause = false;
        }
        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (manager.Peek() != null)
            {
                manager.Pop();
            }
            else
            {
                manager.Push(new MenuPanel());
            }
        }
    }
}
