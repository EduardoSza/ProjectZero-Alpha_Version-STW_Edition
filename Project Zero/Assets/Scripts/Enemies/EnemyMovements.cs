using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    // Antes de tudo, n�s adquirimos os atributos do inimigo e a sua posi��o no jogo:
    EnemyAttributes enemy;
    Vector2 position;

    // Os atributos abaixo servem para as movimenta��es baseadas em seno e cosseno
    // possam ser feitas corretamente:
    private float initialPositionY;
    private float initialPositionX;
    [SerializeField]
    private float amplitude = 1;
    [SerializeField]
    private float frequency = 1;
    [SerializeField]
    private bool inverseFlow = false;

    // A startFlag faz com que um inimigo fa�a alguma coisa apenas quando a "StartingPoint" flag for encontrada:
    [SerializeField]
    private bool startFlag = false;

    public bool StartFlag
    {
        get
        {
            return startFlag;
        }

        set
        {
            startFlag = value;
        }
    }

    void Awake()
    {
        enemy = GetComponent<EnemyAttributes>();
    }

    void Start()
    {
        position = this.transform.position;
        initialPositionY = position.y;
        initialPositionX = position.x;
    }

    // Este movimento faz o inimigo se mover apenas para frente:
    public void GoFoward()
    {
        position.x += -enemy.Speed * Time.deltaTime;
        this.transform.position = position;
    }

    // Este movimento faz o inimigo se mover apenas para frente:
    public void GoBackward()
    {
        position.x += enemy.Speed * Time.deltaTime;
        this.transform.position = position;
    }

    // Este movimento faz o inimigo se movimentar ondas, de acordo com a f�rmula "sen(x)":
    public void SineWaves()
    {
        position.x += -enemy.Speed * Time.deltaTime;
        float sin = Mathf.Sin(position.x * frequency) * amplitude;

        if (inverseFlow == true)
        {
            sin *= -1;
        }

        position.y = initialPositionY + sin;

        transform.position = position;
    }

    // Este movimento faz o inimigo se movimentar ondas, de acordo com a f�rmula "cos(y)":
    public void CossineWaves()
    {
        position.y += -enemy.Speed * Time.deltaTime;
        float cos = Mathf.Cos(position.y * frequency) * amplitude;

        if (inverseFlow == true)
        {
            cos *= -1;
        }

        position.x = initialPositionX + cos;

        transform.position = position;
    }
}
