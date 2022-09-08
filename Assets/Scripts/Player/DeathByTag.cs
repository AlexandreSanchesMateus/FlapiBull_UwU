using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DeathByTag : MonoBehaviour {
    [SerializeField] private string tagName;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag(tagName)) {
            Destroy(this.gameObject);
        }
    }
}
