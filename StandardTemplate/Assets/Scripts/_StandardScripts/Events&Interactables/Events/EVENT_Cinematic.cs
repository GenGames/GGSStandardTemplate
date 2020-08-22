using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EVENT_Cinematic : EventTrigger
{
    public string cinematicName;

    public override void EventTriggered()
    {
        if (CinematicsManager.instance != null)
        {
            CinematicsManager.instance.PlayCinematic(cinematicName);
        }
    }
}