using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    public int oldIndex;

    public int randomMin;
    public int randomMax;

    public void SceneLoad(int index) {
        index = Random.Range(randomMin, randomMax);
        if (index == oldIndex) {
            index = Random.Range(randomMin, randomMax);
        }

        SceneManager.LoadScene(index, LoadSceneMode.Single);
    }
}
