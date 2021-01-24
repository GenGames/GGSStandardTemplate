using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class NeedsTracker : MonoBehaviour
{
    public Need[] needs;

    private void Update()
    {
        foreach (Need need in needs)
        {
            need.Decay();
        }
    }

    public float GetNeedValue(string needName, bool useDesire = false)
    {
        Need need = Array.Find(needs, needObject => needObject.name.ToLower() == needName.ToLower());

        if (need == null)
        {
            Debug.LogError("requested need not found... returning 0");
            return 0;
        }

        if (!useDesire)
        {
            return need.currentValue;
        }
        else
        {
            return need.GetCurrentUrge();
        }
    }

    public void ReplenishNeed(string needName, float replenishValue)
    {
        Need need = Array.Find(needs, needObject => needObject.name.ToLower() == needName.ToLower());
        if (need != null)
        {
            need.Replenish(replenishValue);
        }
        else
        {
            Debug.LogError("requested need not found... returning");
            return;
        }
    }

    public void ModifyNeedDecay(string needName, float decayModifier)
    {
        Need need = Array.Find(needs, needObject => needObject.name.ToLower() == needName.ToLower());
        if (need != null)
        {
            need.decayRatePerSecond += decayModifier;
        }
        else
        {
            Debug.LogError("requested need not found... returning");
            return;
        }
    }

    public void Die()
    {
        _UIManager.instance.LogString(name + " died...");
        Destroy(gameObject);
    }
}

[Serializable]
public class Need
{
    public string name;
    public bool resourceBar = false;
    public float maxValue = 100;
    public float minValue = 0;
    public float currentValue = 50;
    public float decayRatePerSecond = 3;
    public float urgeStrength = 1;
    public bool isDepleting = true;

    public UnityEvent maxedEvent;
    public UnityEvent depletedEvent;

    public void Decay()
    {
        if (isDepleting)
        {
            currentValue += decayRatePerSecond * Time.deltaTime;
            if (currentValue >= maxValue)
            {
                NeedMaxed();
            }
            else if(currentValue <= minValue)
            {
                NeedDepleted();
            }
        }
    }

    public void Replenish(float replenishQuantity)
    {
        currentValue = Mathf.Clamp(currentValue + replenishQuantity, 0, maxValue);
        if (currentValue >= maxValue)
        {
            NeedDepleted();
        }
        else
        {
            isDepleting = true;
        }
    }

    public void NeedDepleted()
    {
        currentValue = minValue;
        Debug.Log("Resource: " + name + " is depleted.");
        depletedEvent.Invoke();
    }

    public void NeedMaxed()
    {
        currentValue = maxValue;
        Debug.Log("Resource: " + name + " is Maxed Out.");
        maxedEvent.Invoke();
    }

    public float GetCurrentUrge()
    {
        if (!resourceBar)
        {
            return currentValue * urgeStrength;
        }
        else
        {
            return (maxValue - currentValue) * urgeStrength; 
        }
    }
}