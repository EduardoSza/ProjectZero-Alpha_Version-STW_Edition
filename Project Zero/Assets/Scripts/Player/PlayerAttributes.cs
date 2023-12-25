using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    [SerializeField]
    private int lifePoints; // Contém a vida do personagem.
    [SerializeField]
    private int attackPower; // Contém o tanto de dano que o ataque do personagem pode dar.
    [SerializeField]
    private float speed; // Contém a velocidade do personagem.

    // Esta variável contém o Animator do player, responsável por administrar todas as suas animações,
    // possuindo também variáveis internas que podem ser vistas na janela Animator:
    [SerializeField]
    private Animator anim;
    // O colider é responsável por permitir que o player encoste e sinta as coisas ao seu redor:
    [SerializeField]
    private BoxCollider2D boxCollider;

    void Update()
    {
        ItMayDie();
    }

    // Get e Set para encapsulamento da variável "lifePoints":
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

    // Get e Set para encapsulamento da variável "speed":
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
            StartCoroutine(Death());
        }
    }

    // O IEnumerator permite que ações acontecem apenas depois de um determinado período de tempo.
    // Neste caso, o boxCollider do player é desativado e a animação de morte é acionada,
    // com o game object sendo destruído momentos depois.
    IEnumerator Death()
    {
        boxCollider.enabled = false;
        anim.SetBool("isDead", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
