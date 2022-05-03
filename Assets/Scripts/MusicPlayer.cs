using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _first;
    [SerializeField] private AudioSource _second;

    void Start()
    {
        _first.Play();
        _second.PlayDelayed(_first.clip.length);
    }


}
