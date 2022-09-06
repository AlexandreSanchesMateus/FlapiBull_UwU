using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private int floatingspeed = 1;

    void Update()
    {
        Move(new Vector2(Input.GetAxisRaw("Horizontal"), floatingspeed));
    }
}
