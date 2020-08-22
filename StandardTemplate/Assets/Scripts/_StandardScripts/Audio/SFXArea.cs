using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SFXArea : MonoBehaviour
{
    private Collider areaOfEffect;
    public AudioSource source;
    public string sound;
    public string tagTrigger;
    public GameObject objectTrigger;
    public bool doesSoundFallOff = true;

    [Range(0.1f, 10000000f)]
    public float soundRangeSquared = 1;

    public bool stopOnExit;

    private void Start()
    {
        //areaOfEffect.isTrigger = true;
        if (source == null)
        {
            source = AudioManager.instance.GetSource(sound);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagTrigger) || other.gameObject == objectTrigger)
        {
            if (AudioManager.instance != null)
            {
                AudioManager.instance.Play(sound);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (doesSoundFallOff)
        {
            if (other.gameObject.CompareTag(tagTrigger) || other.gameObject == objectTrigger)
            {
                if (source != null)
                {
                    source.volume = 1f / (((other.transform.position - transform.position).sqrMagnitude) / soundRangeSquared);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(tagTrigger) || other.gameObject == objectTrigger)
        {
            if (stopOnExit && AudioManager.instance != null)
            {
                AudioManager.instance.Stop(sound);
            }
        }
    }

}
