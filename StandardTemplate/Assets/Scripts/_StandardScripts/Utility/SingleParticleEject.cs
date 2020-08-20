using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleParticleEject : MonoBehaviour
{
    private Vector3 velocity;
    private float lifeTime;
    public Vector3 ejectDirectionMinimum = Vector3.one*-1;
    public Vector3 ejectRangeMaximum = Vector3.one;
    public float scaleFactor =1;
    public float duration =1;
    public float speed =1 ;


    public void EjectParticle()
    {
        velocity = new Vector3(Random.Range(ejectDirectionMinimum.x, ejectRangeMaximum.x),
                                Random.Range(ejectDirectionMinimum.y, ejectRangeMaximum.y),
                                Random.Range(ejectDirectionMinimum.z, ejectRangeMaximum.z)).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if (duration > lifeTime)
        {
            transform.Translate(velocity * Time.deltaTime);
            transform.localScale *= 1 + (scaleFactor * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
