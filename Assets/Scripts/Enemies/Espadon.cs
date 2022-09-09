using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espadon : Entity
{
    [Header("General Settings")]
    [SerializeField] private bool startLeft = true;
    [SerializeField] private Transform leftPosition;
    [SerializeField] private Transform rightPosition;

    private Vector2 newDirection;
    private Vector3 newPosition;
    private bool goBack = false;

    private void Start()
    {
        if (!leftPosition || !rightPosition)
        {
            Debug.LogError("ERROR : Positions de partrouille non défini sur l'enemie ESPADON. GameObject name : " + transform.name + ".");
            this.enabled = false;
            return;
        }

        if (startLeft)
        {
            gameObject.transform.position = leftPosition.position;
            newPosition = rightPosition.position;
        }
        else
        {
            gameObject.transform.position = rightPosition.position;
            newPosition = leftPosition.position;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            goBack = true;
        }
    }

    void FixedUpdate()
    {
        if (!PlayerData.instance.isScoring)
            return;

        newDirection = newPosition - gameObject.transform.position;

        if (newDirection.magnitude < 0.1f)
            if (goBack)
            {
                newPosition = rightPosition.position;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                goBack = false;
            }
            else
            {
                newPosition = leftPosition.position;
                transform.rotation = Quaternion.Euler(0, 180, 0);
                goBack = true;
            }

        Move(newDirection.normalized);
    }
}
