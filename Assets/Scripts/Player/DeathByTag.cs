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

    public void TriggerDeath()
    {
        StartCoroutine(DeathAnim());
    }

    private IEnumerator DeathAnim() {

        PlayerData.instance.Death();
        Animator anim = GetComponent<Animator>();
        anim.SetBool("death", true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("death", false);

        Destroy(this.gameObject);
    }
}
