using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public static SoundPlayer instance;
    public AudioSource source;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public static void Play(AudioClip clip)
    {
        instance.source.clip = clip;
        instance.source.Play();
    }


}
