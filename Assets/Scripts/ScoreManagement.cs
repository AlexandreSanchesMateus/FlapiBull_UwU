using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;

public class ScoreManagement : MonoBehaviour
{

    //public static ScoreManagement instance { get; private set; }

    [SerializeField] private GameObject[] scoreSlot;

    //private SortedDictionary<int, Detail> scoreBoard = new SortedDictionary<int, Detail>();
    //private GameObject canvas;


    /*private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }*/

    private void Start()
    {
        //canvas = gameObject.transform.GetChild(0).gameObject;

        for(int i = 0; i < PlayerData.instance.scoreBoard.ScoreBoard.Count; i++)
        {
            scoreSlot[i].GetComponent<TextMeshProUGUI>().text = "" + PlayerData.instance.scoreBoard.ScoreBoard[i].score;
            scoreSlot[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = PlayerData.instance.scoreBoard.ScoreBoard[i].hour + ":" + PlayerData.instance.scoreBoard.ScoreBoard[i].min + 
                " " + PlayerData.instance.scoreBoard.ScoreBoard[i].month + "/" + PlayerData.instance.scoreBoard.ScoreBoard[i].day;
            
            Debug.Log("Moi");
        }
    }

    void Update()
    {
        if (PlayerData.instance.isDead)
        {
            if (Input.anyKeyDown)
            {
                // Destroy Ancien player
                // PlayerData.instance.isDead = false;
                //Destroy(PlayerData.instance.gameObject);

                // canvas.SetActive(false);
                SceneManager.LoadScene(8, LoadSceneMode.Single);
            }
        }
    }

    /*public void AddScore(int value)
    {
        scoreBoard.Add(value, new Detail());
        if(scoreBoard.Count > 4)
            scoreBoard.Remove(scoreBoard.Keys.First());
        
        canvas.SetActive(true);

        int index = 0;

        foreach(KeyValuePair<int, Detail> paire in scoreBoard)
        {
            scoreSlot[index].GetComponent<TextMeshProUGUI>().text = "" + paire.Key;
            index ++;
        }
    }

    struct Detail
    {
        int hours;
        int seconds;
        int day;
        int month;
    }*/
}
