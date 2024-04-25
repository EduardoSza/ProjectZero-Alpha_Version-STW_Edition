using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserJuggernautMoves : EnemyMovements
{
    // Update is called once per frame
    void Update()
    {
        if (StartFlag == false)
        {
            // O inimigo segue em frente se ainda não encontrou um Starting Point:
            GoFoward();
        }
        else
        {
            // O inimigo fica parado quando encontra um Starting Point...
        }
    }
}
