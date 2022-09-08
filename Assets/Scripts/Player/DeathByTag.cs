using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DeathByTag : MonoBehaviour {
    [SerializeField] private string tagName;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag(tagName)) {
            StartCoroutine(DeathAnim());
        }
    }

    private IEnumerator DeathAnim() {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("death", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("death", false);

        PlayerData.instance.Death();
        Destroy(this.gameObject);
    }
}
