using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(SceneLoader))]
public class EndbyTag : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private float timeBeforeLoad;
    [SerializeField] private string tagName;

    [Header("Fade settings")]

    [SerializeField] private float timer = 0.7f;
    [SerializeField] private Light2D lumiereGeneral;

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

        yield return new WaitForSeconds(timer);
        lumiereGeneral.intensity = 0.66f;
        yield return new WaitForSeconds(timer);
        lumiereGeneral.intensity = 0.33f;
        yield return new WaitForSeconds(timer);
        lumiereGeneral.intensity = 0;

        sceneLoader.SceneLoad();
    }
}
