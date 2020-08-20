using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// THIS SCRIPT HOLDS DATA FROM THE CURRENT PLAYTHROUGH, AND IS NOT DESTROYED ON SCENE LOAD
public class PlayData : MonoBehaviour
{
    #region Singleton
    public static PlayData instance;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

}
