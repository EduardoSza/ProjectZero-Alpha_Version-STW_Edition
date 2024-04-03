using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerAttributes : MonoBehaviour
{
    [SerializeField]
    private int lifePoints; // Cont�m a vida do personagem.
    [SerializeField]
    private int attackPower; // Cont�m o tanto de dano que o ataque do personagem pode dar.
    [SerializeField]
    private float speed; // Cont�m a velocidade do personagem.

    // Esta vari�vel cont�m o Animator do player, respons�vel por administrar todas as suas anima��es,
    // possuindo tamb�m vari�veis internas que podem ser vistas na janela Animator:
    [SerializeField]
    private Animator anim;
    // O colider � respons�vel por permitir que o player encoste e sinta as coisas ao seu redor:
    [SerializeField]
    private BoxCollider2D boxCollider;

    void Update()
    {
        ItMayDie();
    }

    // Get e Set para encapsulamento da vari�vel "lifePoints":
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

    // Get e Set para encapsulamento da vari�vel "attackDamage":
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
            StartCoroutine(Death());
        }
    }

    // O IEnumerator permite que a��es acontecem apenas depois de um determinado per�odo de tempo.
    // Neste caso, o boxCollider do player � desativado e a anima��o de morte � acionada,
    // com o game object sendo destru�do momentos depois.
    IEnumerator Death()
    {
        boxCollider.enabled = false;
        anim.SetBool("isDead", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver");
    }
}
