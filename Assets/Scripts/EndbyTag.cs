using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndbyTag : MonoBehaviour
{
    [SerializeField] private string tagName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == tagName)
        {

        }
    }
}
