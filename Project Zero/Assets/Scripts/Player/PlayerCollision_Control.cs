using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Esse script controla a
public class PlayerCollision_Control : MonoBehaviour
{
    [SerializeField]
    private PlayerMovements playerMovements;
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

    [SerializeField]
    private AudioSource damageSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Quando o jogador passar pela linha de partida "Starting Point", só então poderá controlar o personagem:
        if (collision.gameObject.CompareTag("StartingPoint"))
        {
            playerMovements.StartFlag = true;
        }

        // Se o jogador encostar em um inimigo ou em uma tiro do inimigo, perderá vidas de acordo com o poder do inimigo.

        // Se for um inimigo comum, ele só tira 1 de dano.
        if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyAttacks")) && anim.GetBool("doBarrelRoll") == false)
        {
            playerAttributes.LifePoints--;
            StartCoroutine(Flickering());
        }

        // Se o inimigo for um boss, o jogador morre na hora.
        if (collision.gameObject.CompareTag("Boss") || collision.gameObject.CompareTag("BossAttacks"))
        {
            playerAttributes.LifePoints = 0;
        }
    }

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
