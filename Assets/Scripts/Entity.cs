using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected float speed;

    protected void Move(Vector2 direction)
    {
        gameObject.transform.position = new Vector2(transform.position.x + direction.x * Time.deltaTime, transform.position.y + direction.y * speed * Time.deltaTime);
    }
}