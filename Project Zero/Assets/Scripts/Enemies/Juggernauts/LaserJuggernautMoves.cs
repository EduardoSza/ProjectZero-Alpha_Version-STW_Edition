using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserJuggernautMoves : EnemyMovements
{
    [SerializeField] 
    private EnemyAttributes enemyAttributes;

    // Update is called once per frame
    void Update()
    {
        if (StartFlag == false)
        {

            GoFoward();
        }
        else
        {
            // 0.5 é a velocidade da câmera atual:
            enemyAttributes.Speed = 0.5f;
            GoBackward();
        }
    }
}
