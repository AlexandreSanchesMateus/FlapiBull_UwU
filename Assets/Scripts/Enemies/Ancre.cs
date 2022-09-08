using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ancre : Entity
{

    void Update()
    {
        if (!PlayerData.instance.isScoring)
            return;

        Move(new Vector2(0, -1));
    }

}
