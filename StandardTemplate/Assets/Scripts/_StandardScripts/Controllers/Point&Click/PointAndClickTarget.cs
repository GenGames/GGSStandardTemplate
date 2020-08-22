using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClickTarget : MonoBehaviour
{
    // THIS FILE IS NOT MEANT TO BE CHANGED
    // instead, inheret this file (in addition to monobehaviour) in a different script and override the interacting function

    public virtual void Interacting() // called from the controller, triggers the interaction to be overriden
    {
        print("interacting with " + gameObject.name);
    }
}
