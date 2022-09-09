using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private int floatingSpeed = 1;
    [SerializeField] private float reverseShot = -0.5f;
    private bool canShot = true;

    [SerializeField] private int numberReverseTic = 5;
    [SerializeField] private int oxygeneLost;

    void Update()
    {
        //Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), floatingSpeed);
        //gameObject.transform.position = new Vector2(transform.position.x + direction.x * horizontalSpeed * Time.deltaTime, transform.position.y + direction.y * verticalSpeed * Time.deltaTime);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.JoystickButton1)) && canShot)
        {
            StartCoroutine(Shot());
        }
    }
    private void FixedUpdate()
    {
        if (!PlayerData.instance.isScoring)
            return;

        Move(new Vector2(Input.GetAxisRaw("Horizontal"), floatingSpeed));
    }

    private IEnumerator Shot ()
    {
        for (int i = 0; i < numberReverseTic; i++)
        {
            gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + reverseShot);
            yield return new WaitForSeconds(0.05f);
        }

        canShot = false;
        PlayerData.instance.LostOxygene(oxygeneLost);
        yield return new WaitForSeconds(1);
        canShot = true;
    }
}
