using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EVENT_ActivateObject : EventTrigger
{
    public GameObject target;
    public bool startActive = false;
    public bool doesTriggerOnExit = false;

    private void Start()
    {
        target.SetActive(startActive);
    }

    public override void EventTriggered()
    {
        target.SetActive(!startActive);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && doesTriggerOnExit)
        {
            target.SetActive(startActive);
        }
    }
}
