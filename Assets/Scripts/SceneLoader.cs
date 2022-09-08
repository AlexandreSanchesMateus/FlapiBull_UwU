using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    private int oldIndex;

    public int randomMin;
    public int randomMax;

    private int index = 0;

    public void SceneLoad() {
        if (randomMax - randomMin > 0) {
            do {
                index = Random.Range(randomMin, randomMax);
            } while (index == oldIndex);
        }

        SceneManager.LoadScene(index, LoadSceneMode.Single);
        oldIndex = index;
    }
}