using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision_Control : MonoBehaviour
{

    public Color damageColor;

    [SerializeField]
    private SpriteRenderer sprite;

    // Esta vari�vel cont�m o script que controla os atributos principais e o sistema de vida/morte do inimigo:
    [SerializeField]
    private EnemyAttributes enemyAttributes;
    // Esta vari�vel cont�m o script que permite ao inimigo se movimentar:
    [SerializeField]
    private EnemyMovements enemyMovements;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Este trecho verificado se o game object encostando no inimigo cont�m o script SimpleShot_Control (ou seja, se �
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

        // Starting Point � um game object vazio, dotado de apenas um collisor em trigger.
        // O uso desse if depender� de com ser� programada a movimenta��o do inimigo em quest�o:
        if (collision.gameObject.CompareTag("StartingPoint"))
        {
            enemyMovements.StartFlag = true;
        }
    }

    IEnumerator TakingDamage(){
        sprite.color = damageColor;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }


    
}
