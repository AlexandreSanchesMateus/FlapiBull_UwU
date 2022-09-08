using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oursin : Entity
{
    [Header("General Settings")]
    [SerializeField] private float[] timeInSec;
    [SerializeField] private bool startLeft = false;
    [SerializeField] private bool loop = false;

    [Header("Override Settings")]
    [SerializeField] private bool random = false;
    [SerializeField] private float minRandomValue;
    [SerializeField] private float maxRandomValue;

    private int direction = 0;
    private bool hasBeenActivate = false;


    /*private void Start()
    {
        if (startLeft)
            direction = -1;
        else
            direction = 1;

        if (random)
            StartCoroutine("RandomHorizontalMovement");
        else
            StartCoroutine("HorizontalMovement");
    }*/

    public override void OnActivation()
    {
        hasBeenActivate = true;

        if (startLeft)
            direction = -1;
        else
            direction = 1;

        if (random)
            StartCoroutine("RandomHorizontalMovement");
        else
            StartCoroutine("HorizontalMovement");
    }


    private void Update()
    {

        if (!PlayerData.instance.isScoring)
        {
            if (hasBeenActivate)
            {
                StopAllCoroutines();
                this.enabled = false;
            }

            return;
        }

        Move(new Vector2(direction * horizontalSpeed, -1));

        // Rebondit sur les murs; n'est pas validé par les GD :;(
        /*RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 2);

        if(hitInfo.transform.CompareTag("Death"))
        {
            direction = -direction;
        }*/
    }


    private IEnumerator RandomHorizontalMovement()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minRandomValue, maxRandomValue));
            direction = -direction;
        }
    }

    private IEnumerator HorizontalMovement()
    {
        foreach(float _deltaTime in timeInSec)
        {
            yield return new WaitForSeconds(_deltaTime);
            direction = -direction;
        }

        if (loop)
            StartCoroutine("HorizontalMovement");
    }
}