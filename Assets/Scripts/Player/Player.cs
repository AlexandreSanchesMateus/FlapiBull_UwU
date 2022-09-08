using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private int floatingSpeed = 1;
    [SerializeField] private float reverseShot = -0.5f;
    private bool canShot = true;

    [SerializeField] private int numberReverseTic = 5;

    void Update()
    {
        if (!PlayerData.instance.isScoring)
            return;

        Move(new Vector2(Input.GetAxisRaw("Horizontal"), floatingSpeed));

        if (Input.GetKeyDown(KeyCode.E) && canShot)
        {
            StartCoroutine(Shot());
        }
    }

    private IEnumerator Shot ()
    {
        for (int i = 0; i < numberReverseTic; i++)
        {
            gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + reverseShot);
            yield return new WaitForSeconds(0.05f);
        }

        canShot = false;
        yield return new WaitForSeconds(1);
        canShot = true;
    }
}
