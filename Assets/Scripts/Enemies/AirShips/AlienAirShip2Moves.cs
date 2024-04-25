using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAirShip2Moves : EnemyMovements
{
    public bool invertDirection = false;

    // Update is called once per frame
    void Update()
    {
        if (invertDirection == false)
        {
            GoFoward();
        }
        else 
        { 
            GoBackward();
        }
        
    }
}
