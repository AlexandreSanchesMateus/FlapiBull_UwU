using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class son : MonoBehaviour
{
    public AudioClip mainLoop;
    private AudioSource mainSource;


    void Start()
    {
        mainSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        Debug.Log(mainSource.isPlaying == false);

        if (mainSource.isPlaying == false)
        {
            mainSource.clip = mainLoop;
            mainSource.loop = true;
            mainSource.Play();
        }
    }
}
