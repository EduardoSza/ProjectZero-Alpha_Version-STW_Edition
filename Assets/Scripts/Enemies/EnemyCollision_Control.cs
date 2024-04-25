using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision_Control : MonoBehaviour
{
    // Estas variaveis controlam o SpriteRenderer do inimigo:
    [SerializeField]
    private SpriteRenderer sprite;
    public Color damageColor;
    public bool E_ShieldFlag = false;

    // Esta variavel contem o script que controla os atributos principais e o sistema de vida/morte do inimigo:
    [SerializeField]
    private EnemyAttributes enemyAttributes;
    // Esta variavel contem o script que permite ao inimigo se movimentar:
    [SerializeField]
    private EnemyMovements enemyMovements;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Este trecho verificado se o game object encostando no inimigo contém o script SimpleShot_Control (ou seja, se há
        // uma bala vinda do player). Se for, o inimigo leva o dano corresponente ao attackPower em PlayerAttributes:
        SimpleShot_Control simpleShot = collision.GetComponent<SimpleShot_Control>();
        SuperShot_Control superShot = collision.GetComponent<SuperShot_Control>();

        if (simpleShot != null)
        {
            StartCoroutine(TakingDamage());
            enemyAttributes.LifePoints -= simpleShot.attackPower;
        }
        else if (superShot != null)
        {
            StartCoroutine(TakingDamage());
            enemyAttributes.LifePoints -= superShot.attackPower;
        }

        // Starting Point é um game object vazio, dotado de apenas um collisor em trigger.
        // O uso desse if dependerá de com será programada a movimentação do inimigo em questão:
        if (collision.gameObject.CompareTag("StartingPoint"))
        {
            enemyMovements.StartFlag = true;
        }
    }

    IEnumerator TakingDamage(){
        if (E_ShieldFlag == false)
        {
            sprite.color = damageColor;
        }
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }    
}
