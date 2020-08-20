using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EVENT_Animation : EventTrigger
{
    public AnimationType animationType = AnimationType.Trigger;
    public Animator[] animations;
    public string animatorTriggerString;
    public float animFloatValue;
    public int animIntValue;
    public bool animBoolvalue;
    public bool triggerOnExit;

    public override void EventTriggered()
    {
        foreach (Animator animator in animations)
        {
            switch (animationType)
            {
                case AnimationType.Bool:
                    animator.SetBool(animatorTriggerString,animBoolvalue);
                    break;
                case AnimationType.Float:
                    animator.SetFloat(animatorTriggerString,animFloatValue);
                    break;
                case AnimationType.Int:
                    animator.SetInteger(animatorTriggerString,animIntValue);
                    break;
                case AnimationType.Trigger:
                    animator.SetTrigger(animatorTriggerString);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == eventTriggerObject && triggerOnExit)
        {
            switch (animationType)
            {
                case AnimationType.Bool:
                    animBoolvalue = false;
                    EventTriggered();
                    break;
                case AnimationType.Float:
                    animFloatValue = 0;
                    EventTriggered();
                    break;
                case AnimationType.Int:
                    animIntValue = 0;
                    EventTriggered();
                    break;
                case AnimationType.Trigger:
                    EventTriggered();
                    break;
                default:
                    break;
            }
        }
    }
}

public enum AnimationType
{
    Bool,
    Float,
    Int,
    Trigger
}
