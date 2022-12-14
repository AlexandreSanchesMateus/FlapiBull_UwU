using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header ("Movement Settings")]
    [SerializeField] protected float horizontalSpeed = 1;
    [SerializeField] protected float verticalSpeed = 1;

    protected void Move(Vector2 direction)
    {
        gameObject.transform.position = new Vector2(transform.position.x + direction.x * horizontalSpeed * Time.fixedDeltaTime, transform.position.y + direction.y * verticalSpeed * Time.fixedDeltaTime);
    }

    public virtual void OnActivation()
    {

    }
}