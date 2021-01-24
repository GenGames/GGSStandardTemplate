using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentStats : MonoBehaviour
{
    public float perceptionDistance = 20;
    public float speed;
    public float reachDistance;

    private NavMeshAgent agent;
    public float energyMovementPenalty;
    public bool isStopped;

    private NeedsTracker needs;

    public float[] perceptionRange = new float[2];
    public float[] speedRange = new float[2];

    private void Start()
    {
        isStopped = true;
        agent = GetComponent<NavMeshAgent>();
        needs = GetComponent<NeedsTracker>();
        InitializeAI();
        agent.speed = speed;
        agent.stoppingDistance = reachDistance;
    }

    private void Update()
    {
        if (isStopped != agent.isStopped)
        {
            ToggleEnergyRefreshRate();
        }
    }

    public void ToggleEnergyRefreshRate()
    {

        if (isStopped)
        {
            needs.ModifyNeedDecay("energy", energyMovementPenalty);
        }
        else
        {
            needs.ModifyNeedDecay("energy",-energyMovementPenalty);
        }

        isStopped = !isStopped;
    }

    public void InitializeAI()
    {
        speed = Random.Range(speedRange[0], speedRange[1]);
        perceptionDistance = Random.Range(perceptionRange[0], perceptionRange[1]);
        energyMovementPenalty = speed * -2;
    }
    
}
