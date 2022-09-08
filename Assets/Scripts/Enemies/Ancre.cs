using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class Ancre : Entity
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.transform.GetComponent<AudioSource>();
    }

    void Update()
    {
        Move(new Vector2(0, -1));
    }

    protected override void OnActivation()
    {
        audioSource.Play();
    }
}
