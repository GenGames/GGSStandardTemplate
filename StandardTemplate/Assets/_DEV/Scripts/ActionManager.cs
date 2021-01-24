using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActionManager : MonoBehaviour
{
    private NeedsTracker needs;
    public float refreshTime = 1;
    private float timeSinceLastRefresh;
    public bool isIdle;

    public AiResource[] resources;
    private GetResource getResourceAction;

    private void Start()
    {
        getResourceAction = GetComponent<GetResource>();
        needs = GetComponent<NeedsTracker>();
        timeSinceLastRefresh = 0;
        isIdle = true;
    }

    private void Update()
    {
        if (isIdle)
        {
            if (refreshTime < timeSinceLastRefresh)
            {
                RefreshDecision();
            }
            else
            {
                timeSinceLastRefresh += Time.deltaTime;
            }
        }
    }

    public void RefreshDecision()
    {
        string currentDesire = "laziness";
        float currentDesireValue = needs.GetNeedValue("energy", true);

        foreach (AiResource resource in resources)
        {
            float newDesireValue = needs.GetNeedValue(resource.affectedNeed, true);

            if (currentDesireValue <= newDesireValue)
            {
                currentDesire = resource.affectedNeed;
                currentDesireValue = newDesireValue;
            }
        }

        if (currentDesire != "laziness")
        {
            AiResource desiredResource = Array.Find(resources, needObject => needObject.affectedNeed.ToLower() == currentDesire.ToLower());
            GetResource(desiredResource);
        }
        else
        {
            Idle();
        }


        timeSinceLastRefresh = 0;
    }

    public void GetResource(AiResource resource)
    {
        getResourceAction.FindResourceSources(resource.affectedNeed);
        isIdle = false;
    }


    public void Idle()
    {
        isIdle = true;
    }
}

[System.Serializable]
public class AiResource
{
    public string name;
    public string affectedNeed;
    public string attachedScriptName;
}