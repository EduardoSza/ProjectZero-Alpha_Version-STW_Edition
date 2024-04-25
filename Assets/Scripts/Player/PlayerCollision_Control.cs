using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Esse script controla a
public class PlayerCollision_Control : MonoBehaviour
{
    // Esta variável contém o script que permite ao player se movimentar:
    [SerializeField]
    private PlayerMovements playerMovements;
    // Esta variável contém o script que controla os atributos principais e o sistema de vida/morte do player:
    [SerializeField]
    private PlayerAttributes playerAttributes;
    // Esta variável contém o script os ataques do player:
    [SerializeField]
    private PlayerAttacks playerAttacks;
    // Esta variável contém o script que controla certas animações do player:
    [SerializeField]
    private PlayerAnimationsControl animControl;

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    public Color damageColor;
    [SerializeField]
    private BoxCollider2D boxCollider;
    [SerializeField]
    private float flickeringTime;
    [SerializeField]
    private Animator anim;
    
    private bool noDamageFlag = false;

    // Esta variável armazena o som de dano quando o personagem é atingido:
    [SerializeField]
    private AudioSource damageSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Starting Point é um game object vazio, dotado de apenas um collisor em trigger.
        // Quando o jogador passar pela linha de partida "Starting Point", só então o personagem poderá ser controlado:
        if (collision.gameObject.CompareTag("StartingPoint"))
        {
            playerMovements.StartFlag = true;
        }

        // Se o jogador encostar em um inimigo ou em uma tiro do inimigo, perderá vidas de acordo com o poder do inimigo.
        // Abaixo estão os ifs responsáveis por tudo isso:

        //  - Se for um inimigo comum, ele tira só 1 de dano:
        if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyAttacks")) && anim.GetBool("doBarrelRoll") == false && noDamageFlag == false)
        {
            playerAttributes.LifePoints--;
            StartCoroutine(Flickering());
        }

        //  - Porém e o inimigo for um boss, o jogador morre na hora.:
        if (collision.gameObject.CompareTag("Boss") || collision.gameObject.CompareTag("BossAttacks") && anim.GetBool("doBarrelRoll") == false && noDamageFlag == false)
        {
            playerAttributes.LifePoints = 0;
        }

        //  - Porém e o inimigo for um boss, o jogador morre na hora.:
        if ((collision.gameObject.CompareTag("EnemyAttacks") || collision.gameObject.CompareTag("BossAttacks")) && animControl.isParrying == true)
        {
            playerAttacks.ParryCounter();
        }
    }

    // O IEnumerator permite que ações acontecem apenas depois de um determinado período de tempo.
    // Neste caso, Flickering significa "piscar" e representa o momento quando um player leva dano inimigo,
    // desativando por momentos o sprite do personagem e o seu colisor.
    IEnumerator Flickering()
    {
        noDamageFlag = true;
        damageSound.Play();

        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(flickeringTime/5);
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(flickeringTime/5);
        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(flickeringTime / 5);
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(flickeringTime/5);
        spriteRenderer.color = damageColor;
        yield return new WaitForSeconds(flickeringTime / 5);
        spriteRenderer.color = Color.white;

        noDamageFlag = false;
    }
}
