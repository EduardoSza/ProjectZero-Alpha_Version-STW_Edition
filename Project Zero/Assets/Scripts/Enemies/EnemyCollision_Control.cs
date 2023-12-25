using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision_Control : MonoBehaviour
{
    [SerializeField]
    private EnemyAttributes enemyAttributes;
    [SerializeField]
    private EnemyMovements enemyMovements;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SimpleShot_Control simpleShot = collision.GetComponent<SimpleShot_Control>();
        if (simpleShot != null)
        {
            enemyAttributes.LifePoints -= simpleShot.attackPower;
        }

        // Quando o inimigo passar pela linha de partida "Starting Point", isso acontece:
        if (collision.gameObject.CompareTag("StartingPoint"))
        {
            enemyMovements.StartFlag = true;
        }
    }
}
