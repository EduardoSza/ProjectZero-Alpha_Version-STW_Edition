using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{
    [SerializeField]
    private int lifePoints; // Contém a vida do personagem.
    [SerializeField]
    private int attackPower; // Contém o tanto de dano que o ataque do personagem pode dar.
    [SerializeField]
    private float speed; // Contém a velocidade do personagem.
    [SerializeField]
    private int scoreValue = 0;

    // Esta variável contém o Animator do player, responsável por administrar todas as suas animações,
    // possuindo também variáveis internas que podem ser vistas na janela Animator:
    [SerializeField]
    private Animator anim;
    // O colider é responsável por permitir que o player encoste e sinta as coisas ao seu redor:
    [SerializeField]
    private Collider2D enemyCollider;

    void Update()
    {
        ItMayDie();
    }

    // Get e Set para encapsulamento da variavel "lifePoints":
    public int LifePoints
    {
        get
        {
            return lifePoints;
        }

        set
        {
            lifePoints = value;
        }
    }

    // Get e Set para encapsulamento da variável "attackDamage":
    public int AttackPower
    {
        get
        {
            return attackPower;
        }

        set
        {
            attackPower = value;
        }
    }

    // Get e Set para encapsulamento da vari�vel "speed":
    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    // Faz com que o personagem tenha a capacidade de morrer:
    private void ItMayDie()
    {
        if (lifePoints <= 0) // Se a vida do personagem for menor ou igual a zero, o personagem morre.
        {
            if (enemyCollider.enabled == true)
            {
                GlobalVariables.gameScore += scoreValue;
            }
            enemyCollider.enabled = false;
            anim.SetBool("isDead", true);
            Destroy(gameObject, 0.5f);
        }
    }
}
