using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class levelLoad : MonoBehaviour
{
    public Light2D lumiereGeneral;
    private float intensity_value;
    [SerializeField] private float timer = 0.3f;

    void Start()
    {
        lumiereGeneral.intensity = 0;
        StartCoroutine(Fade());
    }

    private IEnumerator Fade ()
    {
        if (intensity_value == 1)
        {
            yield return new WaitForSeconds(timer);
            lumiereGeneral.intensity = 0.66f;
            yield return new WaitForSeconds(timer);
            lumiereGeneral.intensity = 0.33f;
            yield return new WaitForSeconds(timer);
            lumiereGeneral.intensity = 0;
            intensity_value = 0;
        }
        else
        {
            yield return new WaitForSeconds(timer);
            lumiereGeneral.intensity = 0.33f;
            yield return new WaitForSeconds(timer);
            lumiereGeneral.intensity = 0.66f;
            yield return new WaitForSeconds(timer);
            lumiereGeneral.intensity = 1;
            intensity_value = 1;
        }
    }
}
