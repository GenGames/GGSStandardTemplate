using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenuManager : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.anyKeyDown)
        {
            GameManager.instance.GoToSceneName("LevelSelection");
        }
    }
}
