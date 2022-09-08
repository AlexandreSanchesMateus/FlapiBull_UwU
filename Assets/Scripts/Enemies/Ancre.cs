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
        if (!PlayerData.instance.isScoring)
            return;

        Move(new Vector2(0, -1));
    }

    public override void OnActivation()
    {
        audioSource.Play();
    }
}
