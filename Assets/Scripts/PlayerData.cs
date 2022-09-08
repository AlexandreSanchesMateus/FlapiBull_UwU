using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance { get; private set; }

    [SerializeField] private Text scoreTxt;
    [SerializeField] private Slider oxygeneSlider;
    [SerializeField] private GameObject player;
    [SerializeField] private int oxygenMax = 100;
    [SerializeField] private int oxygenLost = 10;
    [SerializeField] private float timeLosing = 1;

    private Coroutine subRoutine;
    private bool isScoring;
    private float startPosition;

    private int oxygene = 0;
    private int score = 0;
    private int priviousScore = 0;

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
            int depth = (int)(player.transform.position.y - startPosition);
            // Additionne aux tableaux précédents
            score = priviousScore + depth;
            // Update l'affichage
            scoreTxt.text = "" + score;
        }
    }

    public void GainOxygene(int value, bool fullHealth = false)
    {
        // Possibilité de regagner tout son oxygène d'un coup
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
            // A Ajouter
        }
    }

    public void InitDepth()
    {
        startPosition = player.transform.position.y;
        isScoring = true;
        subRoutine = StartCoroutine("LosingOxygene");
    }

    public void StopScoring()
    {
        StopAllCoroutines();
        isScoring = false;
        priviousScore = score;
    }

    // Perd de la vie à temps régulier
    private IEnumerator LosingOxygene()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeLosing);
            LostOxygene(oxygenLost);
        }
    }
}
