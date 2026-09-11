using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager self;
    public AudioSource audioSource;
    void Start()
    {
        self = this;
        audioSource = GetComponent<AudioSource>();
    }
}
