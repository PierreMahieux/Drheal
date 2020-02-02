using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("Music");

        StartCoroutine("Coroutinegooute");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError(name + " : Sound missing");
            return;
        }
        s.source.Play();
    }

    public IEnumerator Coroutinegooute()
    {
        while (true)
        {
            int randnumber = UnityEngine.Random.Range(1, 100);
            int randsound = UnityEngine.Random.Range(1, 3);

            if (randnumber <= 10)
            {
                if (randsound == 1) Play("Goute1");
                if (randsound == 2) Play("Goute2");
                if (randsound == 3) Play("Goute3");
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
