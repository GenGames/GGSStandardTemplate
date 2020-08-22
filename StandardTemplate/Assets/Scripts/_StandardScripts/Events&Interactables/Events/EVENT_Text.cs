using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EVENT_Text : EventTrigger
{
    public Text targetText;
    public string originaltext;
    public string textMessage;

    public bool activeOnStart;
    public bool returnOnExit;

    public bool doesTextFade = true;
    [Range(0.1f, 10000000f)]
    public float textRangeSquared = 1;

    private void Start()
    {
        originaltext = targetText.text;

        targetText.gameObject.SetActive(activeOnStart);
    }

    public override void EventTriggered()
    {
        if (!activeOnStart)
        {
            targetText.gameObject.SetActive(true);
        }

        targetText.text = textMessage;
    }

    private void OnTriggerStay(Collider other)
    {
        if (doesTextFade)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                float alpha = 1f / (((other.transform.position - transform.position).sqrMagnitude) / textRangeSquared);
                Color color = targetText.color;
                color.a = alpha;
                targetText.color = color;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (returnOnExit)
            {
                targetText.text = originaltext;
                targetText.gameObject.SetActive(activeOnStart);
            }
        }
    }
}
