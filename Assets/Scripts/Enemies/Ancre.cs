using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ancre : Entity
{

    void FixedUpdate()
    {
        if (!PlayerData.instance.isScoring)
            return;

        Move(new Vector2(0, -1));
    }

}
