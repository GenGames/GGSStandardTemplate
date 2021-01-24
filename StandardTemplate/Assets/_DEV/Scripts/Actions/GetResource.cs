using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GetResource : MonoBehaviour
{
    private AgentStats my;
    private NavMeshAgent agent;
    private NeedsTracker needs;
    private bool isGathering;
    private ActionManager actions;
    private Transform target;

    private string currentResourceType;

    public void Start()
    {
        actions = GetComponent<ActionManager>();
        agent = GetComponent<NavMeshAgent>();
        my = GetComponent<AgentStats>();
        needs = GetComponent<NeedsTracker>();
    }

    public void FindResourceSources(string type)
    {
        currentResourceType = type;

        List<Transform> resourceSources = new List<Transform>();

        Collider[] thingsINoticed = Physics.OverlapSphere(transform.position, my.perceptionDistance);

        foreach (Collider item in thingsINoticed)
        {
            if (item.GetComponent<Resource_Parent>() != null && item.GetComponent<Resource_Parent>().needName == type)
            {
                resourceSources.Add(item.transform);
            }
        }

        if (resourceSources.Count > 0)
        {
            DetermineBestSource(resourceSources.ToArray());
        }
        else
        {
            OnFailure("I couldn't find any " + type);
        }
    }

    public void DetermineBestSource(Transform[] resourceSources)
    {
        float bestOptionValue = float.MinValue;
        Transform foodSource = null;

        foreach (Transform resourceOption in resourceSources)
        {
            float value = float.MinValue;
            float sqrDistance = (resourceOption.position - transform.position).sqrMagnitude;
            float sqrtime = sqrDistance / (my.speed * my.speed);
            Resource_Parent resource = resourceOption.GetComponent<Resource_Parent>();
            value = resource.availability - sqrtime * 2;


            if (value > bestOptionValue)
            {
                bestOptionValue = value;
                foodSource = resourceOption;
            }
        }

        target = foodSource;
        MoveTowardsFoodSource();
    }

    public void MoveTowardsFoodSource()
    {
        agent.SetDestination(target.position);
        agent.isStopped = false;
        isGathering = true;
    }

    public void Update()
    {
        if (isGathering && target.GetComponent<Resource_Parent>().availability <= target.GetComponent<Resource_Parent>().refreshRate)
        {
            OnFailure("Someone got the resource I wanted");
        }

        if (isGathering && (target.position - transform.position).sqrMagnitude <= (my.reachDistance * my.reachDistance + target.GetComponent<Resource_Parent>().bonusReach) && !agent.isStopped)
        {
            GatherResource(target.GetComponent<Resource_Parent>());
        }
    }

    public void GatherResource(Resource_Parent resource)
    {
        isGathering = false;
        agent.isStopped = true;
        resource.ConsumeResource();

        StartCoroutine(EatFood(resource));
    }

    IEnumerator EatFood(Resource_Parent resource)
    {
        yield return new WaitForSeconds(resource.gatherTime);
        needs.ReplenishNeed(resource.needName, -resource.previousConsumptionValue);
        OnSuccess();
    }

    public void OnSuccess()
    {
        actions.RefreshDecision();
    }

    public void OnFailure(string failMessage)
    {
        isGathering = false;
        agent.isStopped = true;
        _UIManager.instance.LogString(failMessage);

        actions.RefreshDecision();
    }

}
