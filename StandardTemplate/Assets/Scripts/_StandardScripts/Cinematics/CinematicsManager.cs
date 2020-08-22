using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Playables;

public class CinematicsManager : MonoBehaviour
{
    #region Singleton

    public static CinematicsManager instance;
    private void Awake()
    {
        instance = this;
    }

    #endregion

    public CinematicEvent[] cinematics;

    public void Start()
    {
        
    }

    public void PlayCinematic(string cinematicName)
    {
        if (name != "")
        {
            CinematicEvent cinematic = Array.Find(cinematics, CinematicEvent => CinematicEvent.name == cinematicName);
            if (cinematics != null)
            {
                //cinematic.timeline.start = true;
                cinematic.timeline.Play();
            }
            else
            {
                Debug.LogError("Cinematic not found: " + cinematicName);
            }

        }
    }


}

[System.Serializable]
public struct CinematicEvent
{
    public string name;
    public PlayableDirector timeline;
}