using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserJuggernautMoves : EnemyMovements
{
    // Esta variável contêm o script que controla os atributos principais e o sistema de vida/morte do inimigo:
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
        // 0.5 é a velocidade da câmera no momento em que o script foi feito.
        // Portanto, este trecho está sujeito a erros:
            enemyAttributes.Speed = 0.5f;
            GoBackward();
        }
    }
}
