using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManagement : MonoBehaviour
{

    public static ScoreManagement instance { get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Destroy(PlayerData.instance.gameObject);
            Destroy(gameObject);
            SceneManager.LoadScene(2);
        }
    }
}
