using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EventTrigger : MonoBehaviour
{
    private BoxCollider eventRegion;
    public string eventTriggerTag = "Player";
    public GameObject eventTriggerObject;

    // Start is called before the first frame update
    void Start()
    {
        eventRegion = GetComponent<BoxCollider>();
        eventRegion.isTrigger = true;
        if (eventTriggerTag == "")
        {
            eventTriggerTag = "Untagged";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == eventTriggerObject || other.gameObject.CompareTag(eventTriggerTag))
        {
            EventTriggered();
        }
    }

    public virtual void EventTriggered()
    {
        print("event Triggered");
    }
}
