using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySimpleShot_Control : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float timeOfDeath;
    [SerializeField]
    private Animator animator;

    // Update is called once per frame
    void Update()
    {
        ShotDirection();
        ShotLife();
    }

    // Movimentação que faz o game object se movimentar para esquerda:
    private void ShotDirection()
    {
        Vector2 position = this.transform.position;
        Vector2 direction = this.transform.right; // Obter a direção do objeto

        position += direction * -speed * Time.deltaTime; // Adicionar à posição na direção do objeto
        this.transform.position = position;
    }

    // Destrói o game object no qual este script está atrelado depois de um certo tempo:
    private void ShotLife()
    {
        Destroy(this.gameObject, timeOfDeath);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se a bala encontrar um game object com a tag Player, este game object se destruirá.
        // (Obs.: Neste caso específico, a bala está absorvendo o animator gameObject "Sprite" do Player).
        if (collision.gameObject.CompareTag("Player"))
        {
            animator = collision.gameObject.GetComponent<Animator>();

            if (animator != null)
            {
                if (animator.GetBool("doBarrelRoll") == false)
                {
                    Destroy(gameObject, 0.01f);
                }
            }
        }
    }
}
