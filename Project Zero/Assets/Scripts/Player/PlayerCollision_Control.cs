using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Esse script controla a
public class PlayerCollision_Control : MonoBehaviour
{
    // Esta vari�vel cont�m o script que permite ao player se movimentar:
    [SerializeField]
    private PlayerMovements playerMovements;
    // Esta vari�vel cont�m o script que controla os atributos principais e o sistema de vida/morte do player:
    [SerializeField]
    private PlayerAttributes playerAttributes;

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private BoxCollider2D boxCollider;
    [SerializeField]
    private float flickeringTime;
    [SerializeField]
    private Animator anim;

    // Esta vari�vel armazena o som de dano quando o personagem � atingido:
    [SerializeField]
    private AudioSource damageSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Starting Point � um game object vazio, dotado de apenas um collisor em trigger.
        // Quando o jogador passar pela linha de partida "Starting Point", s� ent�o o personagem poder� ser controlado:
        if (collision.gameObject.CompareTag("StartingPoint"))
        {
            playerMovements.StartFlag = true;
        }

        // Se o jogador encostar em um inimigo ou em uma tiro do inimigo, perder� vidas de acordo com o poder do inimigo.
        // Abaixo est�o os ifs respons�veis por tudo isso:

        //  - Se for um inimigo comum, ele tira s� 1 de dano:
        if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyAttacks")) && anim.GetBool("doBarrelRoll") == false)
        {
            playerAttributes.LifePoints--;
            StartCoroutine(Flickering());
        }

        //  - Por�m e o inimigo for um boss, o jogador morre na hora.:
        if (collision.gameObject.CompareTag("Boss") || collision.gameObject.CompareTag("BossAttacks"))
        {
            playerAttributes.LifePoints = 0;
        }
    }

    // O IEnumerator permite que a��es acontecem apenas depois de um determinado per�odo de tempo.
    // Neste caso, Flickering significa "piscar" e representa o momento quando um player leva dano inimigo,
    // desativando por momentos o sprite do personagem e o seu colisor.
    IEnumerator Flickering()
    {
        boxCollider.enabled = false;
        damageSound.Play();

        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(flickeringTime/5);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(flickeringTime/5);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(flickeringTime/5);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(flickeringTime/5);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(flickeringTime/5);
        spriteRenderer.enabled = true;

        boxCollider.enabled = true;
    }
}
