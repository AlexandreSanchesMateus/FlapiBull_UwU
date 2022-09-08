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
        index = Random.Range(randomMin, randomMax);
        if (index == oldIndex) {
            index = Random.Range(randomMin, randomMax);
        }

        SceneManager.LoadScene(index, LoadSceneMode.Single);
        PlayerData.instance.InitDepth();
    }
}