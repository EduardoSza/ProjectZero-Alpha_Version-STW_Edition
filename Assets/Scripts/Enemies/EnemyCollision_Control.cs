using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision_Control : MonoBehaviour
{
    // Esta variável contêm o script que controla os atributos principais e o sistema de vida/morte do inimigo:
    [SerializeField]
    private EnemyAttributes enemyAttributes;
    // Esta variável contêm o script que permite ao inimigo se movimentar:
    [SerializeField]
    private EnemyMovements enemyMovements;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Este trecho verificado se o game object encostando no inimigo contém o script SimpleShot_Control (ou seja, se é
        // uma bala vinda do player). Se for, o inimigo leva o dano corresponente ao attackPower em PlayerAttributes:
        SimpleShot_Control simpleShot = collision.GetComponent<SimpleShot_Control>();
        SuperShot_Control superShot = collision.GetComponent<SuperShot_Control>();
        if (simpleShot != null)
        {
            enemyAttributes.LifePoints -= simpleShot.attackPower;
        }
        else if (superShot != null)
        {
            enemyAttributes.LifePoints -= superShot.attackPower;
        }

        // Starting Point é um game object vazio, dotado de apenas um collisor em trigger.
        // O uso desse if dependerá de com será programada a movimentação do inimigo em questão:
        if (collision.gameObject.CompareTag("StartingPoint"))
        {
            enemyMovements.StartFlag = true;
        }
    }
}
