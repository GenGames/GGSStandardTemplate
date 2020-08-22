using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EVENT_ActivateScript : EventTrigger
{
    public MonoBehaviour[] target;
    public bool startActive = false;
    public bool doesTriggerOnExit = false;

    private void Start()
    {
        for (int i = 0; i < target.Length; i++)
        {
            target[i].enabled = startActive;
        }
    }

    public override void EventTriggered()
    {
        for (int i = 0; i < target.Length; i++)
        {
            target[i].enabled = !startActive;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && doesTriggerOnExit)
        {
            for (int i = 0; i < target.Length; i++)
            {
                target[i].enabled = startActive;
            }
        }
    }
}
