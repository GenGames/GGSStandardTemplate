using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public SoundData[] sounds;
    public AudioSource[] sources;
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (SoundData soundData in sounds)
        {
            soundData.source = gameObject.AddComponent<AudioSource>();
            soundData.source.clip = soundData.sound;
            soundData.source.volume = soundData.volume;
            soundData.source.pitch = soundData.pitch;
            soundData.source.loop = soundData.loop;
            soundData.source.outputAudioMixerGroup = soundData.audioMixerGroup;
            soundData.source.playOnAwake = false;
        }

        sources = GetComponents<AudioSource>();
    }

    public void Play(string name)
    {
        if (name != "")
        {
            SoundData sound = Array.Find(sounds, soundData => soundData.name == name);
            if (sound != null)
            {
                sound.source.Play();
            }
            else
            {
                //Debug.LogError("Sound not found: " + name);
            }

        }
    }

    public bool IsPlaying(string name)
    {
        if (name != "")
        {
            SoundData sound = Array.Find(sounds, soundData => soundData.name == name);
            if (sound != null)
            {
                return sound.source.isPlaying;
            }
            else
            {
                //Debug.LogError("Sound not found: " + name);
                return false;
            }
        }
        else
        {
            //Debug.LogError("Cannot Check sound that is an empty string.");
            return false;
        }
    }

    public void Stop(string name)
    {
        if (name != "")
        {
            SoundData sound = Array.Find(sounds, soundData => soundData.name == name);
            if (sound != null)
            {
                sound.source.Stop();
            }
            else
            {
                // Debug.LogError("Sound not found: " + name);
            }
        }
    }

    public AudioSource GetSource(string name)
    {
        SoundData sound = Array.Find(sounds, soundData => soundData.name == name);
        if (sound != null)
        {
            return sound.source;
        }
        else
        {
            Debug.LogError("no source detected when attempting to recieve the source");
            return null;
        }
    }
}

[System.Serializable]
public class SoundData
{
    public string name;

    public AudioClip sound;

    [Range(0f, 1f)]
    public float volume = .75f;
    [Range(-1f, 2f)]
    public float pitch = 1f;

    public bool loop = false;

    public AudioMixerGroup audioMixerGroup;

    [HideInInspector]
    public AudioSource source;

}