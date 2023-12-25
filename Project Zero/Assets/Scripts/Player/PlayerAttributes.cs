using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    [SerializeField]
    private int lifePoints; // Cont�m a vida do personagem.
    [SerializeField]
    private int attackPower; // Cont�m o tanto de dano que o ataque do personagem pode dar.
    [SerializeField]
    private float speed; // Cont�m a velocidade do personagem.

    [SerializeField]
    private Animator anim;
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

    // Destr�i o objeto atual:
    private void ItMayDie()
    {
        if (lifePoints <= 0) // Se a vida do personagem for menor ou igual a zero, o personagem morre.
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        boxCollider.enabled = false;
        anim.SetBool("isDead", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
