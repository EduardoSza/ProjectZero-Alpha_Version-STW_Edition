using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAirShipMoves : EnemyMovements
{
    // Update is called once per frame
    void Update()
    {
        SineWaves();
    }
}
