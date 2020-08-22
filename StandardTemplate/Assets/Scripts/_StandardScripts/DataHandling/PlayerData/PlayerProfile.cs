using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS SHOULD BE ATTACHED TO THE PLAYER
public class PlayerProfile : MonoBehaviour
{
    #region singleton

    public static PlayerProfile instance;

    private void Awake()
    {
        instance = this;
        if (loadOnAwake)
        {
            LoadGame();
        }
    }

    #endregion

    public bool loadOnAwake;

    // This is the monobehavior interface for allowing users to save data. This script should include ALL THE DATA THAT NEEDS TO BE SAVED
    // (and any data useful for directly processing saved info)


    public int achievementScore;
    public int[] achievementProgress;


    public void SaveGame()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadGame()
    {
        PlayerData player = SaveSystem.LoadPlayer();

        // BE SURE TO ADD ALL OF THE SAVE DATA HERE
        achievementScore = player.achievementScore;
        achievementProgress = player.achievementProgress;
    }
}
