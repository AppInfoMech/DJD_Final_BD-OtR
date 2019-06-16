using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOff : MonoBehaviour
{
    public AudioSource backgroundMusic;


    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            backgroundMusic.enabled = !backgroundMusic.enabled;
        }
    }
}
