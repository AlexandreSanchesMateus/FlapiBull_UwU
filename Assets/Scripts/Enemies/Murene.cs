using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murene : Entity
{
    [Header("General Settings")]
    [SerializeField] private float timeMove;
    [SerializeField] private float timeOut;
    [SerializeField] private float timeIn;
    [SerializeField] private bool startOut;

    private int direction;
    private bool isMoving = false;

    private void Start()
    {
        if (startOut)
            StartCoroutine("GoIn");
        else
            StartCoroutine("GoOut");
    }

    private void Update()
    {
        if (isMoving)
            Move(new Vector2(direction, 0));
    }

    private IEnumerator GoOut()
    {
        isMoving = true;
        direction = 1;
        yield return new WaitForSeconds(timeMove);
        isMoving = false;
        yield return new WaitForSeconds(timeOut);

        StartCoroutine("GoIn");
    }
    
    private IEnumerator GoIn()
    {
        isMoving = true;
        direction = -1;
        yield return new WaitForSeconds(timeMove);
        isMoving = false;
        yield return new WaitForSeconds(timeIn);
       
        StartCoroutine("GoOut");
    }
}
