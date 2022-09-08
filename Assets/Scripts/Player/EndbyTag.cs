using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SceneLoader))]
public class EndbyTag : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private float timeBeforeLoad;
    [SerializeField] private string tagName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == tagName)
        {
            PlayerData.instance.StopScoring();
            StartCoroutine("StopAllBoy");
        }
    }

    private IEnumerator StopAllBoy()
    {
        yield return new WaitForSeconds(0.5f);
        // TRANSITION HERE
        yield return new WaitForSeconds(timeBeforeLoad);
        sceneLoader.SceneLoad();
    }
}
