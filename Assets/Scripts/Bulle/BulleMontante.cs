using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CircleCollider2D))]
public class BulleMontante : Entity
{
    [SerializeField] private int oxigeneGain;

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(new Vector2(0,1));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerData.instance.GainOxygene(oxigeneGain);
            Destroy(this.gameObject);
        }
    }
}
