using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Resource_Parent
{
    // Start is called before the first frame update
    public void Start()
    {
        bonusReach = transform.localScale.x *1.25f;
    }

}
