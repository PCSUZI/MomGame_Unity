using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSound : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip jumpSound;

    // Use this for initialization
    void Start()
    {
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = this.jumpSound;
        this.audio.loop = false;

    }

    // Update is called once per frame
    void Update()
    {
        this.audio.Play();
    }
}
