using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance { get; private set; }

    [SerializeField] private Text scoreTxt;
    [SerializeField] private Slider oxygeneSlider;
    [SerializeField] private GameObject gameOverScene;
    [SerializeField] private GameObject player;
    [SerializeField] private int oxygenMax = 100;
    [SerializeField] private int oxygenLost = 10;
    [SerializeField] private float timeLosing = 1;

    [Header ("Fade settings")]

    [SerializeField] private float timer = 0.7f;
    [SerializeField] private Light2D lumiereGeneral;

    private Coroutine subRoutine;
    public bool isScoring { get; private set; }
    public bool isDead = false;
    private Vector2 startPosition;

    private int oxygene = 0;
    private int score = 0;
    private int priviousScore = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    void Start()
    {
        DontDestroyOnLoad(this.transform);
        oxygene = oxygenMax;
        oxygeneSlider.maxValue = oxygenMax;
        oxygeneSlider.value = oxygene;
        InitDepth();
    }

    private void Update()
    {
        if(isScoring)
        {
            // Calcule la profondeur du tableau
            int depth = (int)(player.transform.position.y - startPosition.y);
            // Additionne aux tableaux précédents
            score = priviousScore + depth;
            // Update l'affichage
            scoreTxt.text = "" + score;
        }

        if (isDead)
        {
            if (Input.anyKeyDown)
            {
                // int indexScene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(8, LoadSceneMode.Single);
                Destroy(this.gameObject);

                /*int count = this.transform.childCount;
                for (int i = 0; i < count; i++)
                    Destroy(this.transform.GetChild(i).gameObject);*/

                // SceneManager.UnloadSceneAsync(indexScene);
                // Invoke("Delay", 0.2f);
            }
        }
    }

    public void GainOxygene(int value, bool fullHealth = false)
    {
        // Possibilité de regagner tout son oxygčne d'un coup
        if (fullHealth)
            oxygene = oxygenMax;
        else
            oxygene = Mathf.Clamp(oxygene + value, 0, oxygenMax);

        // Update Oxygene Indicator
        oxygeneSlider.value = oxygene;
        // Restart Coroutine
        StopCoroutine(subRoutine);
        subRoutine = StartCoroutine("LosingOxygene");
    }

    public void LostOxygene(int value)
    {
        oxygene -= value;
        // Update Oxygene Indicator
        oxygeneSlider.value = oxygene;
        //Mort du Joueur
        if (oxygene <= 0)
        {
            player.GetComponent<DeathByTag>().TriggerDeath();
        }
    }

    public void InitDepth()
    {
        Debug.Log("INIT");

        player.transform.position = new Vector2(player.transform.position.x, -5);
        startPosition = player.transform.position;

        StartCoroutine(Bite());
    }

    public void StopScoring()
    {
        Debug.Log("STOP");

        StopAllCoroutines();
        isScoring = false;
        priviousScore = score;
    }

    public void Death()
    {
        isScoring = false;
        StopAllCoroutines();
        gameOverScene.SetActive(true);
        isDead = true;
    }

    private void Delay()
    {
        // ScoreManagement.instance.AddScore(score);
    }

    // Perd de la vie ŕ temps régulier
    private IEnumerator LosingOxygene()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeLosing);
            LostOxygene(oxygenLost);
        }
    }

    private IEnumerator Bite()
    {
        yield return new WaitForSeconds(timer);
        lumiereGeneral.intensity = 0.33f;
        yield return new WaitForSeconds(timer);
        lumiereGeneral.intensity = 0.66f;
        yield return new WaitForSeconds(timer);
        lumiereGeneral.intensity = 1;

        yield return new WaitForSeconds(0.5f);

        isScoring = true;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Death");
        foreach(GameObject obj in enemies)
        {
            if (obj.TryGetComponent<Entity>(out Entity component))
            {
                component.OnActivation();
            }
        }

        subRoutine = StartCoroutine("LosingOxygene");
    }
}
