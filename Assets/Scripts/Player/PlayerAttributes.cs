using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{
    [SerializeField]
    private Slider lifeBarSlider;
    [SerializeField] 
    private int maxLifePoints;
    [SerializeField]
    private int lifePoints; // Contem a vida do personagem.

    [SerializeField]
    private float speed; // Contem a velocidade do personagem.

    // Esta variavel contem o Animator do player, responsavel por administrar todas as suas animacoes,
    // possuindo tambem variaveis internas que podem ser vistas na janela Animator:
    [SerializeField]
    private Animator anim;

    // O colider e responsavel por permitir que o player encoste e sinta as coisas ao seu redor:
    [SerializeField]
    private BoxCollider2D boxCollider;

    // Usado quando o player morre:
    [SerializeField]
    private AudioSource deathExplosionSound;

    void Start()
    {
        SetLifeBarMax(maxLifePoints);
    }

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
            lifeBarSlider.value = value;
        }
    }

    private void SetLifeBarMax(int life)
    {
        lifeBarSlider.maxValue = life;
        lifeBarSlider.value = life;
        lifePoints = life;
    }

    // Get e Set para encapsulamento da variavel "speed":
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

    // O IEnumerator permite que acoes acontecem apenas depois de um determinado periodo de tempo.
    // Neste caso, o boxCollider do player e desativado e a animacao de morte e acionada,
    // com o game object sendo destruido momentos depois.
    IEnumerator Death()
    {
        boxCollider.enabled = false;
        anim.SetBool("isDead", true);
        //deathExplosionSound.Play();
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
        GameController.instance.ShowGameOver();
    }
}
