using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBulle : MonoBehaviour
{
    [SerializeField] private float timeBeforeSpawn;
    [SerializeField] private GameObject bulle;

    void Start()
    {
        StartCoroutine("SpawnBulle");
    }

    private IEnumerator SpawnBulle()
    {
        yield return new WaitForSeconds(timeBeforeSpawn);
        GameObject instance = Instantiate<GameObject>(bulle);
        instance.transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
    }
}
