using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private void Start()
    {
        Destroy(GlobalVariables.braver);
        Destroy(GlobalVariables.UI);
        GlobalVariables.Pause = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }
}
