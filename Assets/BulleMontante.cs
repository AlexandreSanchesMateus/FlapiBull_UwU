using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CircleCollider2D))]
public class BulleMontante : Entity
{
    [SerializeField] private int oxigeneGain;

    // Update is called once per frame
    void Update()
    {
        Move(new Vector2(0,1));
    }
}
