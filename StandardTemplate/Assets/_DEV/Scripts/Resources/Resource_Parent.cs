using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Parent : MonoBehaviour
{
    public string needName;
    public float availability;
    public float maxAvailability;
    public float refreshRate;
    public float gatherTime;
    public float maxAvilabilityLossOnConsumption;
    public float previousConsumptionValue;
    public bool doesDepleteOnConsumption = true;
    public float bonusReach;

    public virtual void ConsumeResource()
    {
        if (doesDepleteOnConsumption)
        {
            availability -= maxAvilabilityLossOnConsumption;

            if (availability <= maxAvilabilityLossOnConsumption)
            {
                previousConsumptionValue = availability;
            }
            else
            {
                previousConsumptionValue = maxAvilabilityLossOnConsumption;
            }

            availability = Mathf.Clamp(availability, 0, maxAvailability);
        }
        else
        {
            previousConsumptionValue = maxAvilabilityLossOnConsumption;
        }
    }

}
